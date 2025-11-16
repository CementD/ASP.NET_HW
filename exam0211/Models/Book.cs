using System.ComponentModel.DataAnnotations;

namespace exam0211.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string Author { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int CopiesAvailable { get; set; } = 1;
    }
}
