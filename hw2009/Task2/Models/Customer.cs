using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string Phone { get; set; } = null!;

        public ICollection<Order>? Orders { get; set; }
    }
}

