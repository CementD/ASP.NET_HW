using System.ComponentModel.DataAnnotations;

namespace hw2409.Models
{
    public class TicketOrder
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Event Date is required")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        [Required(ErrorMessage = "Tickets Count is required")]
        [Range(1, 10, ErrorMessage = "You can order between 1 and 10 tickets")]
        public int TicketsCount { get; set; }
    }
}
