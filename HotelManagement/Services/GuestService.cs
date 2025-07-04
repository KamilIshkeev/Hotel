using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class GuestService : IGuestService
    {
        private readonly ApplicationDbContext _context;

        public GuestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _context.Guests.FindAsync(id);
        }

        public async Task<Guest> AddGuestAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task UpdateGuestAsync(Guest guest)
        {
            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuestAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
