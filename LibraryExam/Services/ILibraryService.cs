using LibraryExam.DTOs;

namespace LibraryExam.Services
{
    public interface ILibraryService
    {
        Task<bool> BorrowBookAsync(LoanCreateDto dto);
        Task<bool> ReturnBookAsync(int loanId);
    }
}
