using SmartTrip.Services.Interfaces;

namespace SmartTrip.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendBookingConfirmationAsync(string email, string tourName)
        {
            // имитация отправки email — просто выводим в консоль
            await Task.Run(() =>
            {
                Console.WriteLine($"[EmailService] Sent confirmation to {email} for tour: {tourName}");
            });
        }
    }
}
