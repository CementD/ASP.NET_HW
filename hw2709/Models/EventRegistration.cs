using System.ComponentModel.DataAnnotations;

namespace hw2709.Models
{
    public class EventRegistration
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(18, 65)]
        public int Age { get; set; }
    }
}
