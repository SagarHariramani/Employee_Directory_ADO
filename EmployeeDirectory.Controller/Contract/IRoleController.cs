using EmployeeDirectory.Common;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Controller.Contract
{
    public interface IRoleController
    {
        void Add(Role role);
        Role? GetDataById(int roleId);
        int GetRoleCount();
        ValidationResult ValidateDepartment(string department);
        ValidationResult ValidateLocation(string location);
        ValidationResult ValidateRoleName(string roleName);
        int GetRoleId(string roleName, int location, int department);
        List<Role> GetRoles();
        List<Department> GetDepartments();
        List<Location> GetLocations();
        string? GetLocationNameById(int Id);
        string? GetDepartmentNameById(int Id);
        Department? GetDepartmentById(int Id);

    }
}