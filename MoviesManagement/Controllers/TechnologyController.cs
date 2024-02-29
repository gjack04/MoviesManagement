using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly ILogger<EmployeeController> _logger;
        private readonly Mapper _mapper;

        public TechnologyController(
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
            var entity = _ctx.Technologies.Include(r => r.Rooms).ToList();
            return Ok(entity.ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetId(int id)
        {
            Technology? entiy = _ctx.Technologies.Include(r => r.Rooms)
                .SingleOrDefault(a => a.TechnologyId == id);
            if (entiy == null)
                return BadRequest("Nessuna tecnologia trovato");
            return Ok(_mapper.MapEntityToModel(entiy));
        }

        [HttpPost]
        public IActionResult Post(TechnologyModel model)
        {
            model.TechnologyId = 0;
            _ctx.Technologies.Add(_mapper.MapModelToEntity(model));
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        public IActionResult Put(TechnologyModel model)
        {
            Technology? old = _ctx.Technologies.Include(r => r.Rooms)
                .SingleOrDefault(a => a.TechnologyId == model.TechnologyId);
            if (old == null)
                return BadRequest("Nessuna tecnologia trovata");
            old.Name = model.Name;
            old.IsDeleted = model.IsDeleted;
            old.TechnologyType = model.TechnologyType;
            old.Rooms = model?.TechnologyRoom.ConvertAll(_mapper.MapModelToEntity);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id, bool IsDelete)
        {
            Technology? old = _ctx.Technologies.Include(r => r.Rooms)
                .SingleOrDefault(a => a.TechnologyId == id);
            if (old == null)
                return BadRequest("Nessuna tecnologia trovata");
            old.IsDeleted = IsDelete;
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
