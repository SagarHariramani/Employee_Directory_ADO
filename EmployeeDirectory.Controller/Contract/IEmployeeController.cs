using EmployeeDirectory.Common;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Controller.Contract
{
    public interface IEmployeeController
    {
        ValidationResult ValidateDate(string dob);
        ValidationResult ValidateEmail(string email);
        ValidationResult ValidateEmployeeId(string employeeId);
        ValidationResult ValidateFirstName(string firstName);
        ValidationResult ValidateLastName(string lastName);
        ValidationResult ValidatePhoneNumber(string phone);
        Employee GetDataById(string empId);
        void Add(Employee employee);
        List<Employee> GetEmployees();
        void Delete(string employeeId);
        void Edit<T>(string empId, Enum employeeField, T employeeFieldInput);
        List<Manager> GetMangers();
        List<Project> GetProjects();
        string? GetManagerName(int id);
        string? GetProjectName(int? id);
    }
}