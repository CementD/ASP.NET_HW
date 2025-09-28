using System.ComponentModel.DataAnnotations;

namespace hw2709.Models
{
    public class UserRegistration
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
