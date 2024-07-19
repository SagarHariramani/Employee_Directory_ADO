using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contract
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        string? GetDepartmentName(int id);
        Department? GetDepartmentById(int id);
    }
}