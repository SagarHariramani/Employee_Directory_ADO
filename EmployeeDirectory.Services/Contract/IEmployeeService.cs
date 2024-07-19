using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contract
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        void EditEmployee<T>(string empId, Enum fieldName, T fieldInputData);
        void DeleteEmployee(string employeeId);
        Employee? GetEmployeeById(string employeeId);
        List<Employee> GetEmployee();
    }
}
