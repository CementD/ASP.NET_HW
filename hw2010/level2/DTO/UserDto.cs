namespace level2.DTO
{
    public class UserDto
    {
        public string Name { get; set; } = "";
        public AddressDto Address { get; set; } = new();
    }
}
