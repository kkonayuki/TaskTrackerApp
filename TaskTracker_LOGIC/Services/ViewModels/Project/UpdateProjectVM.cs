using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Enums;

namespace TaskTracker_LOGIC.Services.ViewModels.Project
{
    public class UpdateProjectVM
    {
        public string Name { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
