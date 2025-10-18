using System.ComponentModel.DataAnnotations;

namespace SmartTrip.Models
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        public int DestinationId { get; set; }
        public Destination? Destination { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxSeats { get; set; }

        public int BookedSeats { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
