using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OfficeAssetManager.Models;

using static System.Guid;

namespace OfficeAssetManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssetController : ControllerBase
{
    private readonly OfficeAssetManagementContext _context;

    public AssetController(OfficeAssetManagementContext context)
    {
        _context = context;
    }

    //GET: api/Asset/{guid}
    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {

        //var result = (from a in _context.Assets
        //              where a.Guid == guid
        //              join dv in _context.DictionaryValues
        //                  on a.AssetTypeId equals dv.ValueId
        //              join map in _context.AssetAssignments
        //                  on a.AssetId equals map.AssetId
        //              join ee in _context.Employees
        //                  on map.EmployeeId equals ee.EmployeeId
        //              select new AssetDTO
        //              {
        //                  Guid = guid,
        //                  AssetTypeDisplayName = dv.DisplayName,
        //                  AssignedTo = ee.DisplayName
        //              }).FirstOrDefault();

        //return (result == null) ? NoContent() : Ok(result);

        return Ok();
    }
}