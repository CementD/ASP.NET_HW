using LibraryExam.Data;
using LibraryExam.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryExam.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
