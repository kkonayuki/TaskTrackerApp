using Microsoft.AspNetCore.Mvc;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.Project;
using TaskTracker_LOGIC.Services.ViewModels.Project.ProjectQuery;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetProjectsVM>))]

        public IActionResult GetProjects([FromQuery] GetProjectsQueryVM filter)
        {
            var projects = _projectService.GetAllProjects(filter);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(projects);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(200, Type = typeof(GetProjectByIdVM))]
        [ProducesResponseType(400)]

        public IActionResult GetProject(int projectId)
        {
            var project = _projectService.GetProjectById(projectId);
            
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

            if (!_projectService.CreateProject(projectCreate))
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

            if (!_projectService.UpdateProject(projectUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating project");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("ProjectUpdateStatus")]
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

            if (!_projectService.UpdateStatus(projectStatus, projectId))
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

            if (!_projectService.DeleteProject(projectId))
            {
                ModelState.AddModelError("", "Something went wrong deleting Project");
                return BadRequest(ModelState);
            }

            return NoContent();
        }


    }
}
