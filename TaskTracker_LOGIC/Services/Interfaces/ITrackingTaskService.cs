
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Services.Interfaces
{
    public interface ITrackingTaskService
    {
        ICollection<GetTrackingTasksVM> GetAllTrackingTasks();
        ICollection<GetTrackingTaskByIdVM> GetTrackingTasksByProjectId(int id);
        GetTrackingTaskByIdVM GetTrackingTaskById(int trackingTaskId);
        bool UpdateStatus(UpdateTrackingTaskStatusVM trackingTaskStatus, int trackingTaskId);
        bool TrackingTaskExists(int id);
        bool CreateTrackingTask(CreateTrackingTaskVM createTrackingTask, int projectId);
        bool UpdateTrackingTask(UpdateTrackingTaskVM updateTrackingTask);
        bool DeleteTrackingTask(int trackingTaskId);
        bool Save();
    }
}
