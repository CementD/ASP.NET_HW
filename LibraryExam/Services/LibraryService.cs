using LibraryExam.DTOs;
using LibraryExam.Models;
using LibraryExam.Repositories;

namespace LibraryExam.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILoanRepository _loanRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IUserRepository _userRepo;

        public LibraryService(ILoanRepository loanRepo, IBookRepository bookRepo, IUserRepository userRepo)
        {
            _loanRepo = loanRepo;
            _bookRepo = bookRepo;
            _userRepo = userRepo;
        }

        public async Task<bool> BorrowBookAsync(LoanCreateDto dto)
        {
            var user = await _userRepo.GetAsync(dto.UserId);
            if (user == null) return false;

            var book = await _bookRepo.GetAsync(dto.BookId);
            if (book == null) return false;

            if (book.CopiesAvailable <= 0) return false;

            var loan = new Loan
            {
                UserId = dto.UserId,
                BookId = dto.BookId,
                LoanDate = DateTime.UtcNow,
                IsReturned = false
            };

            await _loanRepo.AddAsync(loan);

            book.CopiesAvailable -= 1;
            await _bookRepo.UpdateAsync(book);

            await _loanRepo.SaveChangesAsync();
            await _bookRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ReturnBookAsync(int loanId)
        {
            var loan = await _loanRepo.GetAsync(loanId);
            if (loan == null || loan.IsReturned) return false;

            var book = await _bookRepo.GetAsync(loan.BookId);
            if (book == null) return false;

            loan.IsReturned = true;
            loan.ReturnDate = DateTime.UtcNow;

            await _loanRepo.UpdateAsync(loan);

            book.CopiesAvailable += 1;
            await _bookRepo.UpdateAsync(book);

            await _loanRepo.SaveChangesAsync();
            await _bookRepo.SaveChangesAsync();

            return true;
        }
    }
}
