using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; } // e.g., 1 to 5 stars
        public string Comment { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; } // Navigation property
        public int RoomId { get; set; }
        //public Room Room { get; set; } // Navigation property
        public DateTime DateCreated { get; set; }
    }
}
