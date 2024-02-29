using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;
using MoviesManagement.Models.New;

namespace MoviesManagement.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AgeLimitController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly ILogger<EmployeeController> _logger;
        private readonly Mapper _mapper;

        public AgeLimitController(
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
            List<AgeLimit> entity = _ctx.AgeLimits.Include(m => m.Movies).ToList();
            return Ok(entity.ConvertAll(_mapper.MapEntityToModelFull));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetId(int id)
        {
            AgeLimit? entity = _ctx.AgeLimits.Include(m => m.Movies)
                .SingleOrDefault(a => a.AgeLimitId == id);
            if (entity == null)
                return BadRequest("Nessun age limit trovato");
            return Ok(_mapper.MapEntityToModelFull(entity));
        }

        [HttpPost]
        public IActionResult Post(AgeLimitModel model)
        {
            model.AgeLimitId = 0;
            _ctx.AgeLimits.Add(_mapper.MapModelToEntity(model));
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        public IActionResult Put(AgeLimitModel model)
        {
            AgeLimit? old = _ctx.AgeLimits.SingleOrDefault(a => a.AgeLimitId == model.AgeLimitId);
            if (old == null)
                return BadRequest("Nessun age limit trovato");
            old.Description = model.Description;
            old.IsDeleted = model.IsDeleted;
            old.Movies = model?.MoviesItem.ConvertAll(_mapper.MapModelToEntityMovie);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id, bool IsDelete)
        {
            AgeLimit? old = _ctx.AgeLimits.SingleOrDefault(a => a.AgeLimitId == id);
            if (old == null)
                return BadRequest("Nessun age limit trovato");
            old.IsDeleted = IsDelete;
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
