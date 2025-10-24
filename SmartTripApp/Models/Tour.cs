using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTripApp.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Destination")]
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Attributes.DateNotEarlierThat("today")]
        public DateOnly StartDate { get; set; }

        [Required]
        [Attributes.DateNotEarlierThat("StartDate")]
        public DateOnly EndDate { get; set; }

        [Required]
        [Range(0, 2000)]
        public float Price { get; set; }

        [Required]
        [Range(1, 200)]
        public int MaxSeats { get; set; }

        [Required]
        [Range(0, 200)]
        [DefaultValue(0)]
        public int BookedSeats { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
