using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class CleaningTaskService : ICleaningTaskService
    {
        private readonly ApplicationDbContext _context;

        public CleaningTaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CleaningTask>> GetAllCleaningTasksAsync()
        {
            return await _context.CleaningTasks.ToListAsync();
        }

        public async Task<CleaningTask> GetCleaningTaskByIdAsync(int id)
        {
            return await _context.CleaningTasks.FindAsync(id);
        }

        public async Task<CleaningTask> AddCleaningTaskAsync(CleaningTask CleaningTask)
        {
            _context.CleaningTasks.Add(CleaningTask);
            await _context.SaveChangesAsync();
            return CleaningTask;
        }

        public async Task UpdateCleaningTaskAsync(CleaningTask CleaningTask)
        {
            _context.Entry(CleaningTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCleaningTaskAsync(int id)
        {
            var CleaningTask = await _context.CleaningTasks.FindAsync(id);
            if (CleaningTask != null)
            {
                _context.CleaningTasks.Remove(CleaningTask);
                await _context.SaveChangesAsync();
            }
        }
    }
}
