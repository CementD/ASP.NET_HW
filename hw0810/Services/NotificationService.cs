using hw0810.Models;
using hw0810.Services.Interfaces;

namespace hw0810.Services
{
    public class NotificationService : INotificationService
    {
        private readonly List<Notification> _store = new()
        {
            new Notification{ Id=1, Text="Your order shipped", IsRead=false, UserId=1 },
            new Notification{ Id=2, Text="New arrivals in electronics", IsRead=false, UserId=1 },
            new Notification{ Id=3, Text="Price drop on Laptop", IsRead=false, UserId=2 }
        };

        public Task AddAsync(Notification n)
        {
            n.Id = _store.Any() ? _store.Max(x => x.Id) + 1 : 1;
            _store.Add(n);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Notification>> GetUnreadForUserAsync(int userId)
            => Task.FromResult<IEnumerable<Notification>>(_store.Where(x => x.UserId == userId && !x.IsRead).ToList());

        public Task MarkReadAsync(int id)
        {
            var n = _store.FirstOrDefault(x => x.Id == id);
            if (n != null) n.IsRead = true;
            return Task.CompletedTask;
        }
    }
}
