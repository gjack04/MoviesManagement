using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly Mapper _mapper;
        private readonly ILogger<MovieController> _logger;

        public MovieController(MoviesDbContext ctx, Mapper mapper, ILogger<MovieController> logger)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Movie? entity = _ctx.Movies.Include(m => m.Technologies)
                .Include(m => m.AgeLimit)
                .Include(m => m.Projections)
                .ThenInclude(p => p.Room)
                .SingleOrDefault(m => m.MovieId == id);
            if (entity == null)
            {
                return BadRequest("Film non trovato");
            }
            MovieModel model = _mapper.MapEntityToModel(entity);
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Ingresso nel metodo GetAll del controller MovieController");
            try
            {
                List<Movie> movies = _ctx.Movies.Include(m => m.Technologies)
                    .Include(m => m.AgeLimit)
                    .ToList();

                List<MovieModel> result = movies.ConvertAll(_mapper.MapEntityToModel);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Si è rotto qualcosa");
            }
        }

        [HttpDelete]
        [Route("Disable/{id}")]
        public IActionResult Archive(int id)
        {
            return EnableOrDisable(id, true);
        }

        [HttpDelete]
        [Route("Enable/{id}")]
        public IActionResult Reactivate(int id)
        {
            return EnableOrDisable(id, false);
        }

        private IActionResult EnableOrDisable(int id, bool action)
        {
            var movie = _ctx.Movies.Include(m => m.Projections)
                .SingleOrDefault(m => m.MovieId == id);
            if (movie == null)
                return BadRequest("Impossibile eliminare il film selezionato");

            movie.IsDeleted = action;
            movie.Projections?.ForEach(p => p.IsDeleted = action);

            _ctx.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] MovieModel model)
        {
            model.Id = 0;
            var entity = _mapper.MapModelToEntity(model);
            _ctx.Movies.Add(entity);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] MovieModel model)
        {
            var putMovie = _ctx.Movies.SingleOrDefault(x => x.MovieId == model.Id);
            if (putMovie == null)
                return BadRequest();

            putMovie.MovieId = model.Id;
            putMovie.IsDeleted = model.IsDeleted;
            putMovie.AgeLimitId = model.AgeLimitId;
            putMovie.Title = model.Title;
            putMovie.DurationMins = model.DurationMins;
            putMovie.ImdbId = model.ImdbId;
            putMovie.Technologies = model.Technologies?.ConvertAll(_mapper.MapModelToEntityTech);
            putMovie.Projections = model.Projections?.ConvertAll(_mapper.MapModelToEntity);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
