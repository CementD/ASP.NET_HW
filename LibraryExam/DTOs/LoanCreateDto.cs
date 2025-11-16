using System.ComponentModel.DataAnnotations;

namespace LibraryExam.DTOs
{
    public class LoanCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}
