using System.ComponentModel.DataAnnotations;

namespace WebApplication2209.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
