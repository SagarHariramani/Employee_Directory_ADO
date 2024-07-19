using EmployeeDirectory.Models;

namespace EmployeeDirectory.Data.Contract
{
    public interface IEmployeeHandler
    {
        void AddEmployee(Employee employee);
        List<Employee> GetEmployees();
        Employee? GetEmployeeById(string empId);
        void Update<T>(string empId, Enum fieldName, T fieldInputData);
        void Delete(string empId);
    }
}