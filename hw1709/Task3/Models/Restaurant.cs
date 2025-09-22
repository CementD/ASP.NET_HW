namespace Task3.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Dish> Dishes { get; set; } = new();
    }
}
