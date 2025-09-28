using System.ComponentModel.DataAnnotations;

namespace hw2409.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10,000")]
        public decimal Price { get; set; }
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        public string Description { get; set; }
    }
}
