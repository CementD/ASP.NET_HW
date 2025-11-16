using AutoMapper;
using LibraryExam.DTOs;
using LibraryExam.Models;
using LibraryExam.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? title, [FromQuery] string? author, [FromQuery] string? isbn)
        {
            var list = await _repo.SearchAsync(title, author, isbn);
            var dto = list.Select(b => _mapper.Map<BookDto>(b));
            return Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _repo.GetAsync(id);
            if (book == null) return NotFound();
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] BookCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _repo.ExistsAsync(b => b.ISBN == dto.ISBN))
                return Conflict(new { message = "ISBN must be unique" });

            var book = _mapper.Map<Book>(dto);
            await _repo.AddAsync(book);
            await _repo.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, _mapper.Map<BookDto>(book));
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != dto.Id) return BadRequest();

            var existing = await _repo.GetAsync(id);
            if (existing == null) return NotFound();

            if (existing.ISBN != dto.ISBN)
            {
                if (await _repo.ExistsAsync(b => b.ISBN == dto.ISBN && b.Id != id))
                    return Conflict(new { message = "ISBN must be unique" });
            }

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetAsync(id);
            if (existing == null) return NotFound();

            await _repo.DeleteAsync(existing);
            await _repo.SaveChangesAsync();

            return NoContent();
        }
    }
}
