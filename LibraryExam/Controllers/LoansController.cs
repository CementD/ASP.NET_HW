using AutoMapper;
using LibraryExam.DTOs;
using LibraryExam.Repositories;
using LibraryExam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _loanRepo;
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;

        public LoansController(ILoanRepository loanRepo, ILibraryService libraryService, IMapper mapper)
        {
            _loanRepo = loanRepo;
            _libraryService = libraryService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Borrow([FromBody] LoanCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ok = await _libraryService.BorrowBookAsync(dto);
            if (!ok) return BadRequest(new { message = "Cannot borrow (no copies or invalid user/book)" });

            return Ok(new { message = "Borrowed successfully" });
        }

        [HttpPost("{id:int}/return")]
        [Authorize]
        public async Task<IActionResult> Return(int id)
        {
            var ok = await _libraryService.ReturnBookAsync(id);
            if (!ok) return BadRequest(new { message = "Cannot return" });

            return Ok(new { message = "Returned successfully" });
        }

        [HttpGet("user/{userId:int}")]
        [Authorize]
        public async Task<IActionResult> GetLoansByUser(int userId)
        {
            var loans = await _loanRepo.GetLoansByUserAsync(userId);
            return Ok(loans.Select(l => _mapper.Map<LoanDto>(l)));
        }

        [HttpGet("active/user/{userId:int}")]
        [Authorize]
        public async Task<IActionResult> GetActiveLoans(int userId)
        {
            var loans = await _loanRepo.GetActiveLoansByUserAsync(userId);
            return Ok(loans.Select(l => _mapper.Map<LoanDto>(l)));
        }
    }
}
