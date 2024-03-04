using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly ILogger<EmployeeController> _logger;
        private readonly Mapper _mapper;

        public ProjectionController(
            MoviesDbContext ctx,
            ILogger<EmployeeController> logger,
            Mapper mapper
        )
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _ctx.Projections.Include(a => a.Activities).ToList();
            if (!list.Any())
                return BadRequest();
            return Ok(list.ConvertAll(_mapper.MapEntityToModelProjection));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var list = _ctx.Projections.Include(a => a.Activities)
                .SingleOrDefault(x => x.ProjectionId == id);
            if (list == null)
                return BadRequest();
            return Ok(_mapper.MapEntityToModelProjection(list));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProjectionModel model)
        {
            model.ProjectionId = 0;
            _ctx.Add(_mapper.MapModelToEntityProjection(model));
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
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

        private IActionResult EnableOrDisable(int id, bool enable)
        {
            var projection = _ctx.Projections.SingleOrDefault(x => x.ProjectionId == id);
            if (projection == null)
                return BadRequest("Impossibile eliminare il dipendente selezionato");
            projection.IsDeleted = enable;
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProjectionModel model)
        {
            var projectionPut = _ctx.Projections.SingleOrDefault(x =>
                x.ProjectionId == model.ProjectionId
            );
            if (projectionPut == null)
                return BadRequest();
            projectionPut.ProjectionId = model.ProjectionId;
            projectionPut.IsDeleted = model.IsDeleted;
            projectionPut.MovieId = model.MovieId;
            projectionPut.RoomId = model.RoomId;
            projectionPut.Start = model.Start;
            projectionPut.FreeBy = model.FreeBy;
            projectionPut.Activities = model.ProjectionsActivities?.ConvertAll(
                _mapper.MapModelToEntityActivity
            );
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
