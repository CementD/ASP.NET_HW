using System.ComponentModel.DataAnnotations;

namespace hw1810.DTO
{
    public class ProductUpdateDto
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Range(0, 10000)]
        public int Quantity { get; set; }
    }
}
