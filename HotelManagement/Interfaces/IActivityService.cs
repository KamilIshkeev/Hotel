using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetAllActivitiesAsync();
        Task<Activity> GetActivityByIdAsync(int id);
        Task<Activity> AddActivityAsync(Activity activity);
        Task UpdateActivityAsync(Activity activity);
        Task DeleteActivityAsync(int id);
    }
} 