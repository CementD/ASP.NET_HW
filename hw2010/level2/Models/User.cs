namespace level2.Models
{
    public class User
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public Address Address { get; set; } = new();
    }
}
