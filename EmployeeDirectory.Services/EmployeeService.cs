using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeHandler _employeeHandler;
        public EmployeeService(IEmployeeHandler employeeHandler)
        {
            this._employeeHandler = employeeHandler;
        }
        
        public void AddEmployee(Employee emp)
        {
            _employeeHandler.AddEmployee(emp);
        }
        public void EditEmployee <T>(string empId, Enum fieldName ,T fieldInputData)
        {
            _employeeHandler.Update(empId, fieldName, fieldInputData);
        }
        public void DeleteEmployee(string employeeId)
        {
            _employeeHandler.Delete(employeeId);
        }
        public Employee? GetEmployeeById(string empId)
        {
            return _employeeHandler.GetEmployeeById(empId);
        }
        public List<Employee> GetEmployee()
        {
            return _employeeHandler.GetEmployees();
        }
    }
}
