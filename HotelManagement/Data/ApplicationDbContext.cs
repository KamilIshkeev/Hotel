using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<User> Users { get; set; }
            public DbSet<Room> Rooms { get; set; }
            public DbSet<Booking> Bookings { get; set; }
            public DbSet<CleaningTask> CleaningTasks { get; set; }
            public DbSet<ServiceRequest> ServiceRequests { get; set; }
        }
    
}
