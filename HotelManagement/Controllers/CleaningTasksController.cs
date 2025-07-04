using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CleaningTasksController : ControllerBase
    {
        private readonly ICleaningTaskService _CleaningTaskService;

        public CleaningTasksController(ICleaningTaskService CleaningTaskService)
        {
            _CleaningTaskService = CleaningTaskService;
        }

        // GET: api/CleaningTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CleaningTask>>> GetAllCleaningTasks()
        {
            var CleaningTasks = await _CleaningTaskService.GetAllCleaningTasksAsync();
            return Ok(CleaningTasks);
        }

        // GET: api/CleaningTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CleaningTask>> GetCleaningTask(int id)
        {
            var CleaningTask = await _CleaningTaskService.GetCleaningTaskByIdAsync(id);

            if (CleaningTask == null)
            {
                return NotFound();
            }

            return Ok(CleaningTask);
        }

        // POST: api/CleaningTasks
        [HttpPost]
        public async Task<ActionResult<CleaningTask>> CreateCleaningTask(CleaningTask CleaningTask)
        {
            var createdCleaningTask = await _CleaningTaskService.AddCleaningTaskAsync(CleaningTask);
            return CreatedAtAction(nameof(GetCleaningTask), new { id = createdCleaningTask.Id }, createdCleaningTask);
        }

        // PUT: api/CleaningTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCleaningTask(int id, CleaningTask CleaningTask)
        {
            if (id != CleaningTask.Id)
            {
                return BadRequest();
            }

            await _CleaningTaskService.UpdateCleaningTaskAsync(CleaningTask);
            return NoContent();
        }

        // DELETE: api/CleaningTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCleaningTask(int id)
        {
            await _CleaningTaskService.DeleteCleaningTaskAsync(id);
            return NoContent();
        }
    }
}
