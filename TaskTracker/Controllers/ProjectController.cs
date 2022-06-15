using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.Project;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ITrackingTaskService _taskService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService,ITrackingTaskService taskService, IMapper mapper)
        {
            _projectService = projectService;
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetProjectsVM>))]

        public IActionResult GetProjects()
        {
            var projects = _mapper.Map<List<GetProjectsVM>>(_projectService.GetAllProjects());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(projects);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(200, Type = typeof(GetProjectByIdVM))]
        [ProducesResponseType(400)]

        public IActionResult GetProject(int projectId)
        {
            var project = _mapper.Map<GetProjectByIdVM>(_projectService.GetProjectById(projectId));
            
            foreach (var task in project.Tasks)
            {
                var kek = _mapper.Map<GetTrackingTaskByIdVM>(_taskService.GetTrackingTaskById(task.Id));
                project.Tasks.Add(kek);
            }
            
            if (project == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(project);
        }

        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProject([FromBody] CreateProjectVM projectCreate)
        {
            if (projectCreate == null)
                return BadRequest(ModelState);

            var projectMap = _mapper.Map<Project>(projectCreate);
            if (!_projectService.CreateProject(projectMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully Created");
        }

        [HttpPut("Update")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateProject(int projectId, [FromBody] UpdateProjectVM projectUpdate)
        {
            if (projectUpdate == null)
                return BadRequest(ModelState);

            if (projectId != projectUpdate.Id)
                return BadRequest(ModelState);

            if (!_projectService.ProjectExists(projectId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var projectMap = _mapper.Map<Project>(projectUpdate);

            if (!_projectService.UpdateProject(projectMap))
            {
                ModelState.AddModelError("", "Something went wrong updating project");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("UpdateStatus")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateProjectStatus(int projectId, [FromBody] UpdateProjectStatusVM projectStatus)
        {
            if (projectStatus == null)
                return BadRequest(ModelState);

            if (!_projectService.ProjectExists(projectId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();
            
            var project = _projectService.GetProjectById(projectId);
            
            project.Status = projectStatus.Status;

            if (!_projectService.UpdateStatus(project))
            {
                ModelState.AddModelError("", "Something went wrong updating Project Status");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public IActionResult DeleteProject (int projectId)
        {
            if (!_projectService.ProjectExists(projectId))
                return NotFound();
            
            var projectToDelete = _projectService.GetProjectById(projectId);

            if (!_projectService.DeleteProject(projectToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Project");
                return BadRequest(ModelState);
            }

            return NoContent();
        }


    }
}
