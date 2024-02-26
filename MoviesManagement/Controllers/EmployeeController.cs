using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MoviesDbContext _ctx;
        private readonly ILogger<EmployeeController> _logger;
        private readonly Mapper _mapper;

        public EmployeeController(MoviesDbContext ctx, ILogger<EmployeeController> logger, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _ctx.Employees.Include(a => a.Activities).ToList();
            if (!list.Any())
                return BadRequest();
            return Ok(list.ConvertAll(_mapper.MapEntityToModel));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var item = _ctx.Employees.Include(a => a.Activities).SingleOrDefault(x => x.EmployeeId == id);
            if (item == null)
                return BadRequest();
            return Ok(_mapper.MapEntityToModel(item));
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel model)
        {
            model.Id = 0;
            var entity = _mapper.MapModelToEntity(model);
            _ctx.Employees.Add(entity);
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
            var employee = _ctx.Employees.Include(m => m.Activities).SingleOrDefault(x => x.EmployeeId == id);
            if (employee == null)
                return BadRequest("Impossibile eliminare il dipendente selezionato");
            employee.IsDeleted = enable;
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody]EmployeeModel model)
        {
            var putEmployee = _ctx.Employees.SingleOrDefault(x => x.EmployeeId == model.Id);
            if (putEmployee == null)
                return BadRequest();
            putEmployee.EmployeeId = model.Id;
            putEmployee.Name = model.Name;
            putEmployee.Surname = model.Surname;
            putEmployee.IsDeleted = model.IsDeleted;
            putEmployee.Activities = model.employeeProjectionModels?.ConvertAll(_mapper.MapModelToEntity);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
