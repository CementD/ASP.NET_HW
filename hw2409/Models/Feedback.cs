using System.ComponentModel.DataAnnotations;

namespace hw2409.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Message is required")]
        [StringLength(200, ErrorMessage = "Message cannot exceed 200 characters")]
        public string Message { get; set; }
    }
}
