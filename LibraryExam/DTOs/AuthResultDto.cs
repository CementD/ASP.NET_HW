namespace LibraryExam.DTOs
{
    public class AuthResultDto
    {
        public string Token { get; set; } = "";
        public DateTime ExpiresAt { get; set; }
        public string Role { get; set; } = "";
    }
}
