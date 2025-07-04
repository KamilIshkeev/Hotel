using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class CleaningTask
    {
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Например: "Назначена", "Выполнена"
        public DateTime AssignedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
}
