using OfficeAssetManager.Models;

namespace OfficeAssetManager.Repositories;

public interface IEmployeeRepository 
{
    IEnumerable<Employee> GetEmployees();
    bool HasAssets(int employeeId);
    Employee? GetEmployeeById(int employeeId);
    void InsertEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int employeeId);
    void Save();
}
