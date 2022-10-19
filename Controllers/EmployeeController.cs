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
                        //join AssetAssignment in _context.AssetAssignments 
                        //    on Employee.EmployeeId equals AssetAssignment.EmployeeId
                        //join Asset in _context.Assets
                        //    on AssetAssignment.AssetId equals Asset.AssetId
                        select new Employee
                        {
                            EmployeeId = Employee.EmployeeId,
                            ExternalSystemId = Employee.ExternalSystemId,
                            DisplayName = Employee.DisplayName,
                            FirstName = Employee.FirstName,
                            LastName = Employee.LastName,
                            SiteId = Employee.SiteId,
                            AssetAssignments = Employee.AssetAssignments
                        };

            IEnumerable<Employee> result = query;

            return result;
        }
    }
}
