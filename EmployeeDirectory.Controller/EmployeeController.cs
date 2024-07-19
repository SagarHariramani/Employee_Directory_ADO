using EmployeeDirectory.Common;
using EmployeeDirectory.Controller.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Controller
{
    public class EmployeeController : IEmployeeController
    {
        IEmployeeService _employeeService;
        IValidationService _validationService;
        IManagerService _managerService;
        IProjectService _projectService;
        public EmployeeController(IEmployeeService employeeService, IValidationService validationService, IManagerService managerService, IProjectService projectService)
        {
            this._employeeService = employeeService;
            this._validationService = validationService;
            this._managerService = managerService;
            this._projectService = projectService;
        }
        public ValidationResult ValidateEmployeeId(string employeeId)
        {
            ValidationResult idValidator = _validationService.ValidateEmployeeId(employeeId);
            return idValidator;
        }
        public ValidationResult ValidateFirstName(string firstName)
        {
            ValidationResult firstNameValidator = _validationService.ValidateFirstName(firstName);
            return firstNameValidator;
        }
        public ValidationResult ValidateLastName(string lastName)
        {
            ValidationResult lastNameValidator = _validationService.ValidateLastName(lastName);
            return lastNameValidator;
        }
        public ValidationResult ValidateDate(string dob)
        {
            ValidationResult dobValidator = _validationService.ValidateDate(dob);
            return dobValidator;
        }
        public ValidationResult ValidateEmail(string email)
        {
            ValidationResult emailValidator = _validationService.ValidateEmail(email);
            return emailValidator;
        }
        public ValidationResult ValidatePhoneNumber(string phone)
        {
            ValidationResult phoneValidator = _validationService.ValidatePhoneNumber(phone);
            return phoneValidator;
        }
        public Employee GetDataById(string empId)
        {
            Employee employeeData=_employeeService.GetEmployeeById(empId)!;
            return employeeData;
        }
        public void Add(Employee employee)
        {
            _employeeService.AddEmployee(employee);
        }
        public List<Employee> GetEmployees()
        {
            return _employeeService.GetEmployee();
        }
        public void Delete(string employeeId)
        {
            _employeeService.DeleteEmployee(employeeId);
        }
        public void Edit<T>(string empId, Enum employeeField, T employeeFieldInput)
        {
            _employeeService.EditEmployee(empId, employeeField, employeeFieldInput);
        }
        public List<Manager> GetMangers()
        {
            return _managerService.GetManagers();
        }
        public List <Project> GetProjects()
        {
            return _projectService.GetProjects();
        }
        public string? GetManagerName(int id)
        {
            return _managerService.GetManagerName(id);
        }
        public string? GetProjectName(int? id)
        {
            return _projectService.GetProjectName(id);
        }
        

    }
}
