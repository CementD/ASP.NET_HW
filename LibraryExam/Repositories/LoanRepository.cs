using LibraryExam.Data;
using LibraryExam.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryExam.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Loan>> GetLoansByUserAsync(int userId)
        {
            return await _ctx.Loans
                .Include(l => l.Book)
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetActiveLoansByUserAsync(int userId)
        {
            return await _ctx.Loans
                .Include(l => l.Book)
                .Where(l => l.UserId == userId && !l.IsReturned)
                .ToListAsync();
        }
    }
}
