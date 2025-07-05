using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public int BookedCount { get; set; }
        public int? ResponsibleStaffId { get; set; }
    }
} 