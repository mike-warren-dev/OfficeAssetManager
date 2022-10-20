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

        public EmployeeAssetController(OfficeAssetManagementContext context)
        {
            _context = context;
        }

        // GET: api/Employee/{employeeId}/Assets
        [HttpGet]
        public IActionResult Get(int employeeId)
        {
            var employee = _context.Employees.Where(ee => ee.EmployeeId == employeeId).Any();

            if (!employee) return NoContent();

            var result = (from map in _context.AssetAssignments
                        where map.EmployeeId == employeeId
                        join ee in _context.Employees
                            on map.EmployeeId equals ee.EmployeeId
                        let foo = ee.EmployeeId
                        join Asset in _context.Assets
                            on map.AssetId equals Asset.AssetId
                        join dv in _context.DictionaryValues
                            on Asset.AssetTypeId equals dv.ValueId
                        select new AssetDTO
                        {
                            Guid = Asset.Guid,
                            AssetTypeDisplayName = dv.DisplayName,
                            AssignedTo = ee.DisplayName
                        }).ToList<AssetDTO>();

            return Ok(result);
        }
    }
}
