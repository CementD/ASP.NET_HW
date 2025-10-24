using System.Diagnostics;

namespace SmartTripApp.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendBookingConfirmationAsync(string userEmail, string tourName, int seatsCount)
        {
            await Task.Run(() =>
            {
                Debug.WriteLine($"[EMAIL SERVICE] Sent to: {userEmail}");
                Debug.WriteLine($"Subject: Booking confirmation for {tourName}");
                Debug.WriteLine($"Body: You have successfully booked {seatsCount} seats.");
            });
        }
    }
}
