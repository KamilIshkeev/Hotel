using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class ServiceRequest
    {
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RequestType { get; set; } // Например: "Ремонт", "Обслуживание"
        public string Description { get; set; }
        public string Status { get; set; } // Например: "Открыта", "В процессе", "Закрыта"
        public DateTime CreatedAt { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
}
