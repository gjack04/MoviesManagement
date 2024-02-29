using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

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
            return Ok(_ctx.AgeLimits.Include(m => m.Movies).ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetId(int id)
        {
            AgeLimit? entiy = _ctx.AgeLimits.Include(m => m.Movies)
                .SingleOrDefault(a => a.AgeLimitId == id);
            if (entiy == null)
                return BadRequest("Nessun age limit trovato");
            return Ok(entiy);
        }

        [HttpPost]
        public IActionResult Post(AgeLimit entity)
        {
            entity.AgeLimitId = 0;
            _ctx.AgeLimits.Add(entity);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        public IActionResult Put(AgeLimit entity)
        {
            AgeLimit? old = _ctx.AgeLimits.SingleOrDefault(a => a.AgeLimitId == entity.AgeLimitId);
            if (old == null)
                return BadRequest("Nessun age limit trovato");
            old.Description = entity.Description;
            old.IsDeleted = entity.IsDeleted;
            old.Movies = entity.Movies;
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
