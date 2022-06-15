using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.Project;

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

        public ICollection<GetProjectsVM> GetAllProjects()
        {
            return _mapper.Map<List<GetProjectsVM>>(_context.Projects.ToList());
        }

        public GetProjectByIdVM GetProjectById(int projectId)
        {
            return _mapper.Map<GetProjectByIdVM>(_context.Projects.FirstOrDefault(p => p.Id == projectId));
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
