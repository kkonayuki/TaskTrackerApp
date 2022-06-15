using AutoMapper;
using TaskTracker_DAL;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.Project;
using TaskTracker_LOGIC.Services.ViewModels.Project.ProjectQuery;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ProjectService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateProject(CreateProjectVM project)
        {
            var projectMap = _mapper.Map<Project>(project);
            _context.Add(projectMap);
            return Save();
        }

        public bool DeleteProject(int projectId)
        {
            var deleteProject = _context.Projects.FirstOrDefault(p => p.Id == projectId);
            _context.Remove(deleteProject);
            return Save();
        }

        public ICollection<GetProjectsVM> GetAllProjects(GetProjectsQueryVM filter)
        {
            var query = _context.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            
            if (filter.Priority != null)
            {
                query = query.Where(x => x.Priority == filter.Priority);
            }

            if (filter.StartDate != null)
            {
                query = query.Where(x => x.StartDate >= filter.StartDate);
            }

            if (filter.CompletionDate != null)
            {
                query = query.Where(x => x.StartDate <= filter.CompletionDate);
            }

            var list = query.Select(x => new GetProjectsVM
            {
                Id = x.Id,
                Name = x.Name,
                Priority = x.Priority,
                StartDate = x.StartDate,
            }).ToList();
            return list;
        }

        public GetProjectByIdVM GetProjectById(int projectId)
        {
            var project = _mapper.Map<GetProjectByIdVM>(_context.Projects.FirstOrDefault(p => p.Id == projectId));

            var tasks = _context.TrackingTasks.Where(p => p.Project.Id == projectId).ToList();
            foreach (var task in tasks)
            {
                var taskOfProject = _mapper.Map<GetTrackingTaskByIdVM>(task);
                project.Tasks.Add(taskOfProject);
            }
            
            return project;

        }

        public bool ProjectExists(int id)
        {
            return _context.Projects.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProject(UpdateProjectVM project)
        {
            _mapper.Map<UpdateProjectVM>(_context.Update(project));
            return Save();
        }

        public bool UpdateStatus(UpdateProjectStatusVM project, int projectId)
        {
            var projectStatus = _context.Projects.FirstOrDefault(p => p.Id == projectId);
            projectStatus.Status = project.Status;
            _context.Update(projectStatus);
            return Save();
        }
    }
}
