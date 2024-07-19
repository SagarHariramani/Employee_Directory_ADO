using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contract
{
    public interface IManagerService
    {
        string? GetManagerName(int id);
        List<Manager> GetManagers();
    }
}