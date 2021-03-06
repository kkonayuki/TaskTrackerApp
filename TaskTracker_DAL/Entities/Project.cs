using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Enums;

namespace TaskTracker_DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<TrackingTask>? Tasks { get; set; }
    }
}
