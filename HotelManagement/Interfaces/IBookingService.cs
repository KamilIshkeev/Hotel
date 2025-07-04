using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> AddBookingAsync(Booking room);
        Task UpdateBookingAsync(Booking room);
        Task DeleteBookingAsync(int id);
    }
}
