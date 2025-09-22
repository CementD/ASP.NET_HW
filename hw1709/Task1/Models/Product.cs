namespace Task1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = new();
    }
}
