using HotelManagement.Data;
using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ApplicationDbContext _context;

        public ActivityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task<Activity> AddActivityAsync(Activity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
} 