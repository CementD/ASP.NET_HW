using System.ComponentModel.DataAnnotations;

namespace SmartTrip.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Country { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Url]
        public string? ImageUrl { get; set; }

        public ICollection<Tour>? Tours { get; set; }
    }
}
