using OfficeAssetManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace OfficeAssetManager.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private OfficeAssetManagementContext _context;

    public EmployeeRepository(OfficeAssetManagementContext context)
    {
        _context = context;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }

    public Employee? GetEmployeeById(int employeeId)
    {
        return _context.Employees.Find(employeeId);
    }

    public void InsertEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
    }

    public void UpdateEmployee(Employee employee)
    {
        _context.Entry(employee).State = EntityState.Modified;
    }

    public void DeleteEmployee(int employeeId)
    {
        // unmap any mapped assets.
        List<Asset> assetsToUnassign = _context.Assets.Where(_a => _a.EmployeeId == employeeId).ToList();

        if (assetsToUnassign.Count > 0)
        {
            assetsToUnassign.ForEach(a => a.EmployeeId = null);
            Save();
        }
            
        // delete employee
        Employee employee = _context.Employees.Find(employeeId);
        
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            Save();
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

}
