using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _RoomService;

        public RoomsController(IRoomService RoomService)
        {
            _RoomService = RoomService;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
        {
            var Rooms = await _RoomService.GetAllRoomsAsync();
            return Ok(Rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var Room = await _RoomService.GetRoomByIdAsync(id);

            if (Room == null)
            {
                return NotFound();
            }

            return Ok(Room);
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(Room Room)
        {
            var createdRoom = await _RoomService.AddRoomAsync(Room);
            return CreatedAtAction(nameof(GetRoom), new { id = createdRoom.Id }, createdRoom);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Room Room)
        {
            if (id != Room.Id)
            {
                return BadRequest();
            }

            await _RoomService.UpdateRoomAsync(Room);
            return NoContent();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _RoomService.DeleteRoomAsync(id);
            return NoContent();
        }
    }

}
