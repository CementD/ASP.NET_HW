namespace level3.Models
{
    public class User
    {
        public string Name { get; set; }
        public List<Role> Roles { get; set; } = new();
    }
}
