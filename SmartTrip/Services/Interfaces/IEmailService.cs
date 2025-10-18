namespace SmartTrip.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationAsync(string email, string name);
    }
}
