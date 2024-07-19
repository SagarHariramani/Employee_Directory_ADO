using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;
namespace EmployeeDirectory.Services
{
    public class RoleService : IRoleService
    {
        IRoleHandler _roleHandler;
        public RoleService(IRoleHandler roleHandler)
        {
            this._roleHandler = roleHandler;
        }
        public void AddRole(Role role)
        {
            _roleHandler.AddRole(role);
        }
        public int GetRoleId(string roleName, int location, int department)
        {
            return _roleHandler.GetRoleId(roleName, location, department);
        }
        public int GetRoleCount()
        {
            return _roleHandler.GetRoleCount();
        }
        public Role? GetRoleById(int roleId)
        {
            return _roleHandler.GetRoleById(roleId);
        }
        public List<Role> GetRoles()
        {
            return _roleHandler.GetRoles();
        }


    }
}
