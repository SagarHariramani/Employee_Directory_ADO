using EmployeeDirectory.Models;

namespace EmployeeDirectory.Data.Contract
{
    public interface IDepartmentHandler
    {
        List<Department> GetData();
        string? GetDepartmentNameById(int id);
        Department? GetDepartmentById(int id);
    }
}