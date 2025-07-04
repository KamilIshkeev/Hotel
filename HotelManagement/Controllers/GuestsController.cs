using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _GuestService;

        public GuestsController(IGuestService GuestService)
        {
            _GuestService = GuestService;
        }

        // GET: api/Guests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetAllGuests()
        {
            var Guests = await _GuestService.GetAllGuestsAsync();
            return Ok(Guests);
        }

        // GET: api/Guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
            var Guest = await _GuestService.GetGuestByIdAsync(id);

            if (Guest == null)
            {
                return NotFound();
            }

            return Ok(Guest);
        }

        // POST: api/Guests
        [HttpPost]
        public async Task<ActionResult<Guest>> CreateGuest(Guest Guest)
        {
            var createdGuest = await _GuestService.AddGuestAsync(Guest);
            return CreatedAtAction(nameof(GetGuest), new { id = createdGuest.Id }, createdGuest);
        }

        // PUT: api/Guests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, Guest Guest)
        {
            if (id != Guest.Id)
            {
                return BadRequest();
            }

            await _GuestService.UpdateGuestAsync(Guest);
            return NoContent();
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _GuestService.DeleteGuestAsync(id);
            return NoContent();
        }
    }
}
