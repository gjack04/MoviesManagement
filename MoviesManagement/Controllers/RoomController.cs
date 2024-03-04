using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly ILogger<EmployeeController> _logger;
        private readonly Mapper _mapper;

        public RoomController(
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
            List<Room> lista = _ctx.Rooms.Include(e => e.Projections)
                .Include(e => e.Technologies)
                .ToList();
            return Ok(lista.ConvertAll(_mapper.MapEntityToModelRoom));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetId(int id)
        {
            Room? entity = _ctx.Rooms.Include(e => e.Projections)
                .Include(t => t.Technologies)
                .SingleOrDefault(r => r.RoomId == id);
            if (entity == null)
                return BadRequest("");
            return Ok(_mapper.MapEntityToModelRoom(entity));
        }

        [HttpPost]
        public IActionResult Post(RoomModel model)
        {
            model.RoomId = 0;
            _ctx.Rooms.Add(_mapper.MapModelToEntityFull(model));
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        public IActionResult Put(RoomModel model)
        {
            Room? entity = _ctx.Rooms.Include(e => e.Projections)
                .Include(t => t.Technologies)
                .SingleOrDefault(r => r.RoomId == model.RoomId);
            if (entity == null)
                return BadRequest("");
            entity.IsDeleted = model.IsDeleted;
            entity.Name = model.Name;
            entity.CleanTimeMins = model.CleanTimeMins;
            entity.Projections = model?.Projections.ConvertAll(_mapper.MapModelToEntity);
            entity.Technologies = model?.Technologies.ConvertAll(_mapper.MapModelToEntityTech);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id, bool IsDeleted)
        {
            Room? entity = _ctx.Rooms.Include(e => e.Projections)
                .Include(t => t.Technologies)
                .SingleOrDefault(r => r.RoomId == id);
            if (entity == null)
                return BadRequest("");
            entity.IsDeleted = IsDeleted;
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
