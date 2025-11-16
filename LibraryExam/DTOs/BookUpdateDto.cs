using System.ComponentModel.DataAnnotations;

namespace LibraryExam.DTOs
{
    public class BookUpdateDto
    {
        [Required]
        public int Id { get; set; }

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
