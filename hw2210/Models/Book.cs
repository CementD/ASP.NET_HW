using System.ComponentModel.DataAnnotations;

namespace hw2210.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }
    }
}
