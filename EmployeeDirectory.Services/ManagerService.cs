using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{
    public class ManagerService : IManagerService
    {
        readonly IManagerHandler _managerHandler;
        public ManagerService(IManagerHandler managerHandler)
        {
            _managerHandler = managerHandler;
        }
        public List<Manager> GetManagers()
        {
            return _managerHandler.GetManagers();
        }
        public string? GetManagerName(int id)
        {
            return _managerHandler.GetMangerNameById(id);
        }
    }
}
