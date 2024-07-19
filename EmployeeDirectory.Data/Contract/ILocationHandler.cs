using EmployeeDirectory.Models;

namespace EmployeeDirectory.Data.Contract
{
    public interface ILocationHandler
    {
        List<Location> GetData();
        string? GetLocationNameById(int id);
    }
}