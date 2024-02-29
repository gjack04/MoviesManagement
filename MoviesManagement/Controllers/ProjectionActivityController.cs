using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionActivityController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly ILogger<EmployeeController> _logger;
        private readonly Mapper _mapper;

        public ProjectionActivityController(
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
            var list = _ctx.ProjectionActivities.ToList();
            if (!list.Any())
                return BadRequest();
            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int idP, int idE, int idA)
        {
            var list = _ctx.ProjectionActivities.SingleOrDefault(x =>
                x.ProjectionId == idP && x.EmployeeId == idE && x.ActivityRoleId == idA
            );
            if (list == null)
                return BadRequest();
            return Ok(_mapper.MapEntityToModel(list));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProjectionActivityModel model)
        {
            model.ProjectionId = 0;
            _ctx.Add(_mapper.MapModelToEntity(model));
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int idP, int idE, int idA)
        {
            var list = _ctx.ProjectionActivities.SingleOrDefault(x =>
                x.ProjectionId == idP && x.EmployeeId == idE && x.ActivityRoleId == idA
            );
            if (list == null)
                return BadRequest();
            _ctx.ProjectionActivities.Remove(list);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
