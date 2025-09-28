using System.ComponentModel.DataAnnotations;

namespace hw2709.Models
{
    public class Feedback
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
