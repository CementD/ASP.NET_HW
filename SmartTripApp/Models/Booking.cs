using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTripApp.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Tour")]
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(1, 10)]
        public int Seats { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
