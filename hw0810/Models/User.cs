using System.ComponentModel.DataAnnotations;

namespace hw0810.Models
{
    public enum Role
    {
        Admin,
        User
    }
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public Role Role { get; set; } = Role.User;
    }
}
