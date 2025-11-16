using exam0211.Data;
using exam0211.DTOs;
using exam0211.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exam0211.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _db;
        public LoansController(AppDbContext db) => _db = db;

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LoanBook([FromBody] LoanDto dto)
        {
            var book = await _db.Books.FindAsync(dto.BookId);
            var user = await _db.Users.FindAsync(dto.UserId);
            if (book == null || user == null) return NotFound("Book or user not found");
            if (book.CopiesAvailable <= 0) return BadRequest("No copies available");

            var loan = new Loan { BookId = book.Id, UserId = user.Id, LoanDate = DateTime.UtcNow };
            book.CopiesAvailable--;
            _db.Loans.Add(loan);
            await _db.SaveChangesAsync();
            return Ok(loan);
        }

        [Authorize]
        [HttpPost("{id:int}/return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var loan = await _db.Loans.Include(l => l.Book).FirstOrDefaultAsync(l => l.Id == id);
            if (loan == null || loan.IsReturned) return NotFound("Loan not found or already returned");

            loan.IsReturned = true;
            loan.ReturnDate = DateTime.UtcNow;
            loan.Book!.CopiesAvailable++;
            await _db.SaveChangesAsync();
            return Ok(loan);
        }

        [Authorize]
        [HttpGet("user/{userId:int}")]
        public async Task<IActionResult> GetLoansByUser(int userId)
        {
            var loans = await _db.Loans
                .Include(l => l.Book)
                .Where(l => l.UserId == userId && !l.IsReturned)
                .ToListAsync();
            return Ok(loans);
        }
    }
}
