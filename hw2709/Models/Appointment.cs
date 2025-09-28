using System.ComponentModel.DataAnnotations;

namespace hw2709.Models
{
    public class Appointment
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [NotFutureDate(ErrorMessage = "Date cannot be in the future.")]
        public DateTime Date { get; set; }
    }
}
