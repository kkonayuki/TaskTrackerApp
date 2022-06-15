using Microsoft.AspNetCore.Mvc;
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

        public TrackingTaskController(ITrackingTaskService taskService,IProjectService projectService)
        {
            _taskService = taskService;
            _projectService = projectService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetTrackingTasksVM>))]

        public IActionResult GetTrackingTasks()
        {
            var tasks = _taskService.GetAllTrackingTasks();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(200, Type = typeof(GetTrackingTaskByIdVM))]
        [ProducesResponseType(400)]

        public IActionResult GetTrackingTask(int trackingTaskId)
        {
            var trackingTask = _taskService.GetTrackingTaskById(trackingTaskId);
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

            if (!_taskService.CreateTrackingTask(trackingTaskCreate, projectId))
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

        public IActionResult UpdateTrackingTask(int trackingTaskId, [FromBody] UpdateTrackingTaskVM trackingTaskUpdate)
        {
            if (trackingTaskUpdate == null)
                return BadRequest(ModelState);

            if (trackingTaskId != trackingTaskUpdate.Id)
                return BadRequest(ModelState);

            if (!_taskService.TrackingTaskExists(trackingTaskId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_taskService.UpdateTrackingTask(trackingTaskUpdate))
            {
                ModelState.AddModelError("", "Something went wrong updating Task");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("TaskUpdateStatus")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateTrackingTaskStatus(int trackingTaskId, [FromBody] UpdateTrackingTaskStatusVM updateStatusTask)
        {
            if (updateStatusTask == null)
                return BadRequest(ModelState);

            if (!_taskService.TrackingTaskExists(trackingTaskId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_taskService.UpdateStatus(updateStatusTask, trackingTaskId))
            {
                ModelState.AddModelError("", "Something went wrong updating Task Status");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
