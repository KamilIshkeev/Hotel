using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Например: "Admin", "Staff", "Guest"
        public int? GuestId { get; set; } // Необязательно, если это связано с моделью Guest

        public Guest Guest { get; set; }
    }
}
