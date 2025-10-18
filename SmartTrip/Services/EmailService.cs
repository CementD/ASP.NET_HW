using SmartTrip.Services.Interfaces;

namespace SmartTrip.Services
{
    public class EmailService : IEmailService
    {
        public Task SendConfirmationAsync(string email, string name)
        {
            Console.WriteLine($"[EmailService] Confirmation sent to {name} ({email}).");
            return Task.CompletedTask;
        }
    }
}