using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityRoleController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly ILogger<EmployeeController> _logger;
        private readonly Mapper _mapper;

        public ActivityRoleController(
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
            var list = _ctx.ActivityRoles.Include(x => x.Activities).ThenInclude(x => x.Employee).ToList();
            if (!list.Any())
                return BadRequest();
            return Ok(list.ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var item = _ctx.ActivityRoles.Include(x => x.Activities).ThenInclude(x => x.Employee).SingleOrDefault(a => a.ActivityRoleId == id);
            if (item == null)
                return BadRequest();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(ActivityRoleModel model)
        {
            var entity = _mapper.MapModelToEntity(model);
            _ctx.ActivityRoles.Add(entity);
            return _ctx.SaveChanges() > 0 ? Ok(entity) : BadRequest();
        }

        [HttpPut]
        public IActionResult Put(ActivityRoleModel model)
        {
            var entity = _ctx.ActivityRoles.SingleOrDefault(x => x.ActivityRoleId == model.Id);
            if (entity == null)
                return BadRequest();
            entity.ActivityRoleId = model.Id;
            entity.IsDeleted = model.IsDeleted;
            entity.Description = model.Description;
            return _ctx.SaveChanges() > 0 ? Ok(entity) : BadRequest();
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
            var entity = _ctx.ActivityRoles.SingleOrDefault(x => x.ActivityRoleId == id);
            if (entity == null)
                return BadRequest("Impossibile eliminare il dipendente selezionato");
            entity.IsDeleted = enable;
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id, bool IsDeleted)
        {
            ActivityRole? old = _ctx.ActivityRoles.Include(e => e.Activities)
                .SingleOrDefault(a => a.ActivityRoleId == id);
            if (old == null)
                return BadRequest();
            old.IsDeleted = IsDeleted;
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
