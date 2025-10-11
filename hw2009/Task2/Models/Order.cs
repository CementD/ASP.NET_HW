using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public enum OrderStatus
    {
        New,
        Processing,
        Shipped,
        Cancelled,
        Completed
    }

    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public OrderStatus Status { get; set; } = OrderStatus.New;

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}

