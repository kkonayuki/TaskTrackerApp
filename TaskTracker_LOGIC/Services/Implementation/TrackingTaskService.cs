using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Services.Implementation
{
    public class TrackingTaskService : ITrackingTaskService
    {
        private readonly DatabaseContext _context;

        public TrackingTaskService(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateProject(TrackingTask createTrackingTask)
        {
            _context.Add(createTrackingTask);
            return Save();
        }

        public bool DeleteProject(TrackingTask trackingTask)
        {
            _context.Remove(trackingTask);
            return Save();

        }

        public ICollection<TrackingTask> GetAllTrackingTasks()
        {
            return _context.TrackingTasks.OrderBy(t => t.Id).ToList();
        }

        public TrackingTask GetTrackingTaskById(int trackingTaskId)
        {
            return _context.TrackingTasks.FirstOrDefault(t => t.Id == trackingTaskId);
        }

        public ICollection<TrackingTask> GetTrackingTasksByProjectId(int id)
        {
            return _context.TrackingTasks.OrderBy(t => t.Project.Id == id).ToList();
        }

        public bool TrackingTaskExists(int id)
        {
            return _context.TrackingTasks.Any(t => t.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProject(TrackingTask updateTrackingTask)
        {
            _context.Update(updateTrackingTask);
            return Save();
        }

        public bool UpdateStatus(TrackingTask trackingTaskStatus)
        {
            _context.Update(trackingTaskStatus);
            return Save();
        }
    }
}
