using System.ComponentModel.DataAnnotations;

namespace exam0211.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime MembershipDate { get; set; } = DateTime.UtcNow;
    }
}
