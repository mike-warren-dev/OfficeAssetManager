using Microsoft.AspNetCore.Mvc;
using OfficeAssetManager.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeAssetManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly OfficeAssetManagementContext _context;

        public EmployeeController(OfficeAssetManagementContext context)
        {
            _context = context;
        }

        // GET: api/Employee/{employeeId}
        [HttpGet("{employeeId}")]
        public IActionResult Get(int employeeId)
        {
            var query = from ee in _context.Employees
                        where ee.EmployeeId == employeeId
                        join dv in _context.DictionaryValues
                            on ee.SiteId equals dv.ValueId
                        select new EmployeeDTO
                        {
                            EmployeeId = ee.EmployeeId,
                            ExternalSystemId = ee.ExternalSystemId,
                            DisplayName = ee.DisplayName,
                            SiteName = dv.DisplayName
                        };

            IEnumerable<EmployeeDTO> result = query;


            return (query.Any()) ? Ok(result) : NoContent();
        }
    }
}
