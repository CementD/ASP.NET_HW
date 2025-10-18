namespace hw0610.Services
{
    public class FakeEmailService : IEmailService
    {
        public string SendEmail(string to)
        {
            return "Test email sent to {to}";
        }
    }
}
