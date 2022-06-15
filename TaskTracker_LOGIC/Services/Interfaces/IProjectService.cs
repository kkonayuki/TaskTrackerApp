
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.ViewModels.Project;

namespace TaskTracker_LOGIC.Services.Interfaces
{
    public interface IProjectService
    {
        ICollection<Project> GetAllProjects();
        Project GetProjectById(int projectId);
        bool UpdateStatus(Project project);
        bool ProjectExists(int id);
        bool CreateProject(Project project);
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);
        bool Save();
    }
}
