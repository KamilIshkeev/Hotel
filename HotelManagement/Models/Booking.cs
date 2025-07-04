using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; } // Например: "Подтверждено", "Отменено"

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
}
