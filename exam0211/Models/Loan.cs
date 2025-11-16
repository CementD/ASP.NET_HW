using System.ComponentModel.DataAnnotations;

namespace exam0211.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; } = false;
    }
}
