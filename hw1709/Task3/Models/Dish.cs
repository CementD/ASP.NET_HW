namespace Task3.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public List<DishCategory> DishCategories { get; set; } = new();
    }
}
