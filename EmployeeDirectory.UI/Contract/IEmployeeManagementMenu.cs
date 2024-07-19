using EmployeeDirectory.Models;

namespace EmployeeDirectory.UI.Contract
{
    public interface IEmployeeManagementMenu
    {
        void DisplayEmployeeData(Employee employeeData);
        void EmployeeManagmentMenuOptions();
        int GetDepartmentId(int location);
        string GetJobTitle(int location, int department);
        int GetLocationId();
        void OptionAddEmployee();
        void OptionDeleteParticularEmployee();
        void OptionDisplayAllEmployeeData();
        void OptionDisplayEmployeeById();
        void OptionEditEmployee(Employee employeeData, string employeeID);
    }
}