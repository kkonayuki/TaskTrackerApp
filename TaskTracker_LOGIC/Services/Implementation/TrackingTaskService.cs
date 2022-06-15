using AutoMapper;
using TaskTracker_DAL;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Services.Implementation
{
    public class TrackingTaskService : ITrackingTaskService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public TrackingTaskService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateTrackingTask(CreateTrackingTaskVM createTrackingTask, int projectId)
        {
            var taskMap = _mapper.Map<TrackingTask>(_context.Add(createTrackingTask));
            taskMap.Project.Id = projectId;
            _context.Add(taskMap);
            return Save();
        }

        public bool DeleteTrackingTask(int trackingTaskId)
        {
            var deleteTask = _context.TrackingTasks.FirstOrDefault(p => p.Id == trackingTaskId);
            _context.Remove(deleteTask);
            return Save();

        }

        public ICollection<GetTrackingTasksVM> GetAllTrackingTasks()
        {
            return _mapper.Map<List<GetTrackingTasksVM>>(_context.TrackingTasks.ToList());
        }

        public GetTrackingTaskByIdVM GetTrackingTaskById(int trackingTaskId)
        {
            return _mapper.Map<GetTrackingTaskByIdVM>(_context.TrackingTasks.FirstOrDefault(t => t.Id == trackingTaskId));
        }

        public ICollection<GetTrackingTaskByIdVM> GetTrackingTasksByProjectId(int id)
        {
            return _mapper.Map<List<GetTrackingTaskByIdVM>>(_context.TrackingTasks.OrderBy(t => t.Project.Id == id).ToList());
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

        public bool UpdateTrackingTask(UpdateTrackingTaskVM updateTrackingTask)
        {
            _mapper.Map<UpdateTrackingTaskVM>(_context.Update(updateTrackingTask));
            return Save();
        }

        public bool UpdateStatus(UpdateTrackingTaskStatusVM trackingTaskStatus, int trackingTaskId)
        {
            var updateTask = _context.TrackingTasks.FirstOrDefault(t => t.Id == trackingTaskId);
            updateTask.Status = trackingTaskStatus.Status;
            _context.Update(updateTask);
            return Save();
        }
    }
}
