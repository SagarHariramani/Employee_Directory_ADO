using EmployeeDirectory.Common;
using EmployeeDirectory.Controller.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Controller
{
    public class RoleController : IRoleController
    {
        IRoleService _roleService;
        IDepartmentService _departmentService;
        ILocationService _locationService;
        IValidationService _validationService;
        public RoleController(IRoleService roleService, IValidationService validationService, ILocationService locationService,IDepartmentService departmentService)
        {
            this._roleService = roleService;
            this._validationService = validationService;
            this._departmentService = departmentService;
            this._locationService = locationService;
        }
        public ValidationResult ValidateRoleName(string roleName)
        {
            ValidationResult roleNameValidator = _validationService.ValidateRoleName(roleName);
            return roleNameValidator;
        }
        public ValidationResult ValidateLocation(string location)
        {
            ValidationResult locationValidation = _validationService.ValidateLocation(location);
            return locationValidation;
        }
        public ValidationResult ValidateDepartment(string department)
        {
            ValidationResult departmentValidation = _validationService.ValidateDepartment(department);
            return departmentValidation;
        }
        public void Add(Role role)
        {
            _roleService.AddRole(role);
        }
        public int GetRoleCount()
        {
            return _roleService.GetRoleCount();
        }
        public Role? GetDataById(int roleId)
        {
            return _roleService.GetRoleById(roleId);
        }
        public int GetRoleId(string roleName, int location, int department)
        {
            return _roleService.GetRoleId(roleName, location, department);
        }
        public List<Role> GetRoles()
        {
            return _roleService.GetRoles();
        }
        public List<Department> GetDepartments()
        {
            return _departmentService.GetDepartments();
        }
        public List<Location> GetLocations()
        {
            return _locationService.GetLocations();
        }
        public string? GetLocationNameById(int Id)
        {
            return _locationService.GetLocationName(Id);
        }
        public string? GetDepartmentNameById(int Id)
        {
            return _departmentService.GetDepartmentName(Id);
        }
        public Department? GetDepartmentById(int Id)
        {
            return _departmentService.GetDepartmentById(Id);
        }
       
    }
}
