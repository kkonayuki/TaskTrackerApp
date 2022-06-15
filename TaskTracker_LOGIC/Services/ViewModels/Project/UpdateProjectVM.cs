
using TaskTracker_DAL.Enums;

namespace TaskTracker_LOGIC.Services.ViewModels.Project
{
    public class UpdateProjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
