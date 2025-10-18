using hw0810.Models;

namespace hw0810.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetUnreadForUserAsync(int userId);
        Task AddAsync(Notification n);
        Task MarkReadAsync(int id);
    }
}
