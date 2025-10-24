using System.ComponentModel.DataAnnotations;

namespace SmartTrip.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int TourId { get; set; }
        public Tour? Tour { get; set; }

        [Required, StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(1, 100)]
        public int Seats { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
