using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace SmartTripApp.Models
{
    public enum Country { USA, Canada, Mexico, UK, France, Germany, Italy, Spain, Australia, Japan, China, India, Ukraine }
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public Country Country { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public List<Tour> Tours { get; set; }
    }
}
