
using TaskTracker_DAL.Enums;

namespace TaskTracker_LOGIC.Services.ViewModels.TrackingTask
{
    public class CreateTrackingTaskVM
    {
        public string Name { get; set; }
        public TrackingTaskStatus Status { get; set; }
        public string Description { get; set; }
        public TrackingTaskPriority Priority { get; set; }
    }
}
