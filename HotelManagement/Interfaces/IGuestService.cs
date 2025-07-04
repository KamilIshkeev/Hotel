using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAllGuestsAsync();
        Task<Guest> GetGuestByIdAsync(int id);
        Task<Guest> AddGuestAsync(Guest guest);
        Task UpdateGuestAsync(Guest guest);
        Task DeleteGuestAsync(int id);
    }
}
