
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.ViewModels.Project;

namespace TaskTracker_LOGIC.Services.Interfaces
{
    public interface IProjectService
    {
        ICollection<GetProjectsVM> GetAllProjects();
        GetProjectByIdVM GetProjectById(int projectId);
        bool UpdateStatus(UpdateProjectStatusVM project, int projectId);
        bool ProjectExists(int id);
        bool CreateProject(CreateProjectVM project);
        bool UpdateProject(UpdateProjectVM project);
        bool DeleteProject(int projectId);
        bool Save();
    }
}
