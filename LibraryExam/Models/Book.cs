using System.ComponentModel.DataAnnotations;

namespace LibraryExam.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(250)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Author { get; set; } = string.Empty;

        [Required, StringLength(17)]
        public string ISBN { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int CopiesAvailable { get; set; }
    }
}
