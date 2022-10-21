using Microsoft.AspNetCore.Mvc;
using OfficeAssetManager.Models;
using OfficeAssetManager.Repositories;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeAssetManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _repository;

    public EmployeeController(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Employee/Get/{employeeId}
    [HttpGet("Get/{employeeId}")]
    public IActionResult Get(int employeeId)
    {
        Employee employee = _repository.GetEmployeeById(employeeId);

        return (employee == null) ? NoContent() : Ok(employee);
    }

    // GET: api/Employee/Delete/{employeeId}
    [HttpDelete("Delete/{employeeId}")]
    public IActionResult Delete(int employeeId)
    {
        var employee = _repository.GetEmployeeById(employeeId);

        if (employee == null)
        {
            return NotFound();
        }
        else
        {
            _repository.DeleteEmployee(employeeId);
            return Ok();
        }
    }

    // GET: api/Employee/Insert
    [HttpPost("Insert")]
    public IActionResult Insert([FromBody][Bind("LastName,FirstName,ExternalSystemId,SiteId")] Employee employee)
    {
        _repository.InsertEmployee(employee);

        return Ok();
    }
}
