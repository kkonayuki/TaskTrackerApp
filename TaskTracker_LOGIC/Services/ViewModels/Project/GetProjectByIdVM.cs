using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker_DAL.Enums;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Services.ViewModels.Project
{
    public class GetProjectByIdVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<GetTrackingTaskByIdVM> TrackingTasks { get; set; }
    }
}
