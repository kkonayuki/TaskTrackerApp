
using TaskTracker_DAL.Enums;

namespace TaskTracker_LOGIC.Services.ViewModels.Project
{
    public class GetProjectsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
