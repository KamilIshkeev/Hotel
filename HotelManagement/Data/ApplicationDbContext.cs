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
            public DbSet<Activity> Activities { get; set; }
            public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Room>()
                .Property(r => r.PricePerNight)
                .HasColumnType("decimal(18, 2)");

            //modelBuilder.Entity<Review>()
            //    .HasOne(r => r.User)
            //    .WithMany()
            //    .HasForeignKey(r => r.UserId)
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            //modelBuilder.Entity<Review>()
            //    .HasOne(r => r.Room)
            //    .WithMany()
            //    .HasForeignKey(r => r.RoomId)
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            base.OnModelCreating(modelBuilder);
        }
        }
    
}
