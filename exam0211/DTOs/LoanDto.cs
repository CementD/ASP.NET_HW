using System.ComponentModel.DataAnnotations;

namespace exam0211.DTOs
{
    public class LoanDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}