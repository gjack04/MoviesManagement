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

        public ActivityRoleController(MoviesDbContext ctx, ILogger<EmployeeController> logger, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _ctx.ActivityRoles.Include(x => x.Activities.Select(y => y.Employee).Distinct().ToList()).ToList();
            if (!list.Any())
                return BadRequest();
            return Ok(list.ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var list = _ctx.ActivityRoles.Include()
        }
    }
}
