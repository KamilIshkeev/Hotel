using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<Booking> AddBookingAsync(Booking Booking)
        {
            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();
            return Booking;
        }

        public async Task UpdateBookingAsync(Booking Booking)
        {
            _context.Entry(Booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int id)
        {
            var Booking = await _context.Bookings.FindAsync(id);
            if (Booking != null)
            {
                _context.Bookings.Remove(Booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
