using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contract
{
    public interface IRoleService
    {
        void AddRole(Role role);
        int GetRoleId(string roleName, int location, int department);
        int GetRoleCount();
        Role? GetRoleById(int roleId);
        List<Role> GetRoles();

    }
}
