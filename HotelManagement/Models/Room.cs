using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; } // Напр.: "Стандарт", "Люкс"
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        //public ICollection<Booking> Bookings { get; set; }
    }
}
