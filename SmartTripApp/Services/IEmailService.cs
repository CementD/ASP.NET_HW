namespace SmartTripApp.Services
{
    public interface IEmailService
    {
        Task SendBookingConfirmationAsync(string userEmail, string tourName, int seatsCount);
    }
}
