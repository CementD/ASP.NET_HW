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
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BooksController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search)
        {
            var query = _db.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(b => b.Title.Contains(search) || b.Author.Contains(search) || b.ISBN.Contains(search));
            var books = await query.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _db.Books.FindAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _db.Books.AnyAsync(b => b.ISBN == dto.ISBN)) return BadRequest("ISBN must be unique");

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                CopiesAvailable = dto.CopiesAvailable
            };
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDto dto)
        {
            var book = await _db.Books.FindAsync(id);
            if (book == null) return NotFound();
            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            book.CopiesAvailable = dto.CopiesAvailable;
            await _db.SaveChangesAsync();
            return Ok(book);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if (book == null) return NotFound();
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
