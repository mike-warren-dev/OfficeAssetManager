using OfficeAssetManager.Models;
using Microsoft.EntityFrameworkCore;

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
        Employee employee = _context.Employees.Find(employeeId);
        _context.Employees.Remove(employee);
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
