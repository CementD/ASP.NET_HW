using LibraryExam.Models;

namespace LibraryExam.Repositories
{
    public interface ILoanRepository : IRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetLoansByUserAsync(int userId);
        Task<IEnumerable<Loan>> GetActiveLoansByUserAsync(int userId);
    }
}
