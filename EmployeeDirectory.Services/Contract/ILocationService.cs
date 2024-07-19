using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contract
{
    public interface ILocationService
    {
        List<Location> GetLocations();
        string? GetLocationName(int id);
    }
}