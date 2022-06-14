using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Services.Implementation
{
    public class TrackingTaskService : ITrackingTaskService
    {
        public bool CreateProject(CreateTrackingTaskVM createTrackingTaskVm)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(int trackingTaskId)
        {
            throw new NotImplementedException();
        }

        public ICollection<GetTrackingTasksVM> GetAllTrackingTasks()
        {
            throw new NotImplementedException();
        }

        public GetTrackingTaskByIdVM GetTrackingTaskById(int trackingTaskId)
        {
            throw new NotImplementedException();
        }

        public ICollection<GetTrackingTasksVM> GetTrackingTasksByProjectId(int id)
        {
            throw new NotImplementedException();
        }

        public bool ProjectExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProject(UpdateTrackingTaskVM updateTrackingTaskVm)
        {
            throw new NotImplementedException();
        }
    }
}
