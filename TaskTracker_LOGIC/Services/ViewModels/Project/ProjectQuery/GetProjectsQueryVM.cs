
using TaskTracker_DAL.Enums;

namespace TaskTracker_LOGIC.Services.ViewModels.Project.ProjectQuery
{
    public class GetProjectsQueryVM
    {
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectPriority? Priority { get; set; }
    }
}
