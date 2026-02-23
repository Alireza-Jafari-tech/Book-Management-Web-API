using Microsoft.AspNetCore.Mvc;
using apiApp.DTOs;
using apiApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace apiApp.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>?> GetBooksAsync()
        {
            var books = await _bookService.GetBooksAsync();

            if (books == null || !books.Any())
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookCreateDto bookCreateDto)
        {
            var createdBook = await _bookService.CreateBookAsync(bookCreateDto);

            return Ok(createdBook);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] BookUpdateDto bookUpdateDto)
        {
            var bookExists = await _bookService.BookExistsAsync(id);
            if (!bookExists)
            {
                return NotFound();
            }

            var updatedBook = await _bookService.UpdateBookAsync(id, bookUpdateDto);
            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var bookExists = await _bookService.BookExistsAsync(id);
            if (!bookExists)
            {
                return NotFound();
            }

            var result = await _bookService.DeleteBookAsync(id);
            if (!result)
            {
                return StatusCode(500, "something went wrong");
            }

            return NoContent();
        }
    }
}