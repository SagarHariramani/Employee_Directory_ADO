using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Contract
{
    public interface IProjectService
    {
        string? GetProjectName(int? id);
        List<Project> GetProjects();
    }
}