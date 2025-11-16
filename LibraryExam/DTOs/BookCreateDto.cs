using System.ComponentModel.DataAnnotations;

namespace LibraryExam.DTOs
{
    public class BookCreateDto
    {
        [Required, StringLength(250)]
        public string Title { get; set; } = "";

        [Required, StringLength(200)]
        public string Author { get; set; } = "";

        [Required, StringLength(17)]
        public string ISBN { get; set; } = "";

        [Range(0, int.MaxValue)]
        public int CopiesAvailable { get; set; }
    }
}
