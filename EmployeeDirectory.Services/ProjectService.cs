using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{
    public class ProjectService : IProjectService
    {
        readonly IProjectHandler _projectHandler;
        public ProjectService(IProjectHandler projectHandler)
        {
            _projectHandler = projectHandler;
        }
        public List<Project> GetProjects()
        {
            return _projectHandler.GetData();
        }
        public string? GetProjectName(int? id)
        {
            return _projectHandler.GetProjectNameById(id);
        }
    }
}
