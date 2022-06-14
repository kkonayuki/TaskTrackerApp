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

        public ProjectService(DatabaseContext context)
        {
            _context = context;
        }
        public bool CreateProject(Project project)
        {
            _context.Add(project);
            return Save();
        }

        public bool DeleteProject(Project project)
        {
            _context.Remove(project);
            return Save();
        }

        public ICollection<Project> GetAllProjects()
        {
            return _context.Projects.OrderBy(p => p.Id).ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == projectId);
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

        public bool UpdateProject(Project project)
        {
            _context.Update(project);
            return Save();
        }
    }
}
