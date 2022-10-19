using Microsoft.AspNetCore.Mvc;
using OfficeAssetManager.Models;
using System.Diagnostics;

namespace OfficeAssetManager.Controllers
{
    [Route("api/Employee/{employeeId}/Assets")]
    [ApiController]
    public class EmployeeAssetController : ControllerBase
    {
        private readonly OfficeAssetManagementContext _context;

        public EmployeeAssetController(ILogger<WeatherForecastController> logger, OfficeAssetManagementContext context)
        {
            _context = context;
        }

        // GET: api/Employee/{employeeId}/Assets
        [HttpGet]
        public IActionResult Get(int employeeId)
        {
            var nameQuery = _context.Employees.Where(ee => ee.EmployeeId == employeeId).Select(ee => ee.DisplayName).FirstOrDefault();

            if (nameQuery == null) return NoContent();

            var query = from AssetAssignment in _context.AssetAssignments
                        where AssetAssignment.EmployeeId == employeeId
                        join Asset in _context.Assets
                            on AssetAssignment.AssetId equals Asset.AssetId
                        join dv in _context.DictionaryValues
                            on Asset.AssetTypeId equals dv.ValueId
                        select new AssetDTO
                        {
                            AssetId = Asset.AssetId,
                            Guid = Asset.Guid,
                            AssetTypeDisplayName = dv.DisplayName
                        };
            
            EmployeeAssetDTO result = new() { EmployeeDisplayName = nameQuery ,Assets = query.ToList<AssetDTO>() };

            return Ok(result);
        }
    }
}
