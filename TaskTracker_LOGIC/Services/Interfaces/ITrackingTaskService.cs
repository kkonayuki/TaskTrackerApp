using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Services.Interfaces
{
    public interface ITrackingTaskService
    {
        ICollection<TrackingTask> GetAllTrackingTasks();
        ICollection<TrackingTask> GetTrackingTasksByProjectId(int id);
        TrackingTask GetTrackingTaskById(int trackingTaskId);
        bool UpdateStatus(TrackingTask trackingTaskStatus);
        bool TrackingTaskExists(int id);
        bool CreateProject(TrackingTask createTrackingTask);
        bool UpdateProject(TrackingTask updateTrackingTask);
        bool DeleteProject(TrackingTask trackingTask);
        bool Save();
    }
}
