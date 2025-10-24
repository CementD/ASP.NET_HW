namespace SmartTrip.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendBookingConfirmationAsync(string email, string tourName);
    }
}
