using Microsoft.AspNetCore.Mvc;
using OfficeAssetManager.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeAssetManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly OfficeAssetManagementContext _context;

        public EmployeeController(ILogger<WeatherForecastController> logger, OfficeAssetManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/Employee/{employeeId}
        [HttpGet("{employeeId}")]
        public IEnumerable<Employee> Get(int employeeId)
        {
            var query = from Employee in _context.Employees
                        where Employee.EmployeeId == employeeId
                        select Employee;

            IEnumerable<Employee> result = query;

            return result;
        }
    }
}
