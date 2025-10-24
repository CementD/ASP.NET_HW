using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrip.Models
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        public int DestinationId { get; set; }
        public Destination? Destination { get; set; }

        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Range(1, 1000)]
        public int MaxSeats { get; set; }

        public int BookedSeats { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
