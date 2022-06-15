using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.Interfaces;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingTaskController : ControllerBase
    {
        private readonly ITrackingTaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public TrackingTaskController(ITrackingTaskService taskService,IProjectService projectService, IMapper mapper)
        {
            _taskService = taskService;
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetTrackingTasksVM>))]

        public IActionResult GetTrackingTasks()
        {
            var tasks = _mapper.Map<List<GetTrackingTasksVM>>(_taskService.GetAllTrackingTasks());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(200, Type = typeof(GetTrackingTaskByIdVM))]
        [ProducesResponseType(400)]

        public IActionResult GetTrackingTask(int trackingTaskId)
        {
            var trackingTask = _mapper.Map<GetTrackingTaskByIdVM>(_taskService.GetTrackingTaskById(trackingTaskId));
            if (trackingTask == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(trackingTask);
        }

        [HttpPost("Create")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateTrackingTask([FromQuery] int projectId, [FromBody] CreateTrackingTaskVM trackingTaskCreate)
        {
            if (trackingTaskCreate == null)
                return BadRequest(ModelState);

            var taskMap = _mapper.Map<TrackingTask>(trackingTaskCreate);

            taskMap.Project = _projectService.GetProjectById(projectId);

            if (!_taskService.CreateProject(taskMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully Created");
        }
    }
}
