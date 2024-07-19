using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{
    public class LocationService : ILocationService
    {
        ILocationHandler _locationHandler;
        public LocationService(ILocationHandler locationHandler)
        {
            _locationHandler = locationHandler;
        }
        public List<Location> GetLocations()
        {
            List<Location> locations = _locationHandler.GetData();
            return locations;

        }
        public string? GetLocationName(int id)
        {
            return _locationHandler.GetLocationNameById(id);
        }
    }
}
