namespace hw0610.Services
{
    public class EmailService : IEmailService
    {
        public string SendEmail(string to)
        {
            return $"Email sent to {to}";
        }
    }
}
