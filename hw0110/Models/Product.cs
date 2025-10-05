using System.ComponentModel.DataAnnotations;

namespace hw0110.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "100 symbols max")]
        public string Name { get; set; }
        [Required]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000")]
        public decimal Price { get; set; }
    }
}
