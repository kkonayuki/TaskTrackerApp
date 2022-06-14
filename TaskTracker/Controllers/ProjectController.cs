using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.Project;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetProjectsVM>))]

        public IActionResult GetProjects()
        {
            var projects = _mapper.Map<List<GetProjectsVM>>(_projectService.GetAllProjects());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        [ProducesResponseType(200, Type = typeof(GetProjectByIdVM))]
        [ProducesResponseType(400)]

        public IActionResult GetCountry(int projectId)
        {
            var project = _mapper.Map<GetProjectByIdVM>(_projectService.GetProjectById(projectId));
            if (project == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(project);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProject([FromBody] CreateProjectVM projectCreate)
        {
            if(projectCreate == null)
                return BadRequest(ModelState);

            var projectMap = _mapper.Map<Project>(projectCreate);
            if (!_projectService.CreateProject(projectMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully Created");
        }
    }
}
