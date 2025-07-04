using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface ICleaningTaskService
    {
        Task<IEnumerable<CleaningTask>> GetAllCleaningTasksAsync();
        Task<CleaningTask> GetCleaningTaskByIdAsync(int id);
        Task<CleaningTask> AddCleaningTaskAsync(CleaningTask CleaningTask);
        Task UpdateCleaningTaskAsync(CleaningTask CleaningTask);
        Task DeleteCleaningTaskAsync(int id);
    }
}
