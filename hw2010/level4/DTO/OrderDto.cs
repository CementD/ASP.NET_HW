namespace level4.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string UserName { get; set; } = "";
        public int TotalItems { get; set; }
        public List<string> ProductNames { get; set; } = new();
    }
}
