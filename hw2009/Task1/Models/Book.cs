using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(13)]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ISBN must be 13 digits.")]
        public string ISBN { get; set; }
        [Required]
        [Range(1500, 2025, ErrorMessage = "Publish year must be between 1500 and the current year.")]
        public int PublishYear { get; set; }
        public int AuthorId { get; set; }
        [Required]
        public Author Author { get; set; }
        public List<Genre> Genres { get; set; } = new();
    }
}
