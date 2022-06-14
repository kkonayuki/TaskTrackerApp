using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Services.Interfaces
{
    public interface ITrackingTaskService
    {
        ICollection<GetTrackingTasksVM> GetAllTrackingTasks();
        ICollection<GetTrackingTasksVM> GetTrackingTasksByProjectId(int id);
        GetTrackingTaskByIdVM GetTrackingTaskById(int trackingTaskId);
        bool ProjectExists(int id);
        bool CreateProject(CreateTrackingTaskVM createTrackingTaskVm);
        bool UpdateProject(UpdateTrackingTaskVM updateTrackingTaskVm);
        bool DeleteProject(int trackingTaskId);
        bool Save();
    }
}
