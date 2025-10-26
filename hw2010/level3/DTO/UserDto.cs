namespace level3.DTO
{
    public class UserDto
    {
        public string Name { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}
