using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentHandler _departmentHandler;
        public DepartmentService(IDepartmentHandler departmentHandler)
        {
            _departmentHandler = departmentHandler;
        }
        public List<Department> GetDepartments()
        {
            return _departmentHandler.GetData();
        }
        public string? GetDepartmentName(int id)
        {
            return _departmentHandler.GetDepartmentNameById(id);
        }
        public Department? GetDepartmentById(int id)
        {
            return _departmentHandler.GetDepartmentById(id);
        }
    }
}
