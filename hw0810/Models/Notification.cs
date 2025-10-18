using System.ComponentModel.DataAnnotations;

namespace hw0810.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public bool IsRead { get; set; } = false;

        [Display(Name = "User Id")]
        public int UserId { get; set; }
    }
}
