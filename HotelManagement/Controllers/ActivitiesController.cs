using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetAllActivities()
        {
            var activities = await _activityService.GetAllActivitiesAsync();
            return Ok(activities);
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // POST: api/Activities
        [HttpPost]
        public async Task<ActionResult<Activity>> CreateActivity(Activity activity)
        {
            var createdActivity = await _activityService.AddActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivity), new { id = createdActivity.Id }, createdActivity);
        }

        // PUT: api/Activities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            await _activityService.UpdateActivityAsync(activity);
            return NoContent();
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            await _activityService.DeleteActivityAsync(id);
            return NoContent();
        }
    }
} 