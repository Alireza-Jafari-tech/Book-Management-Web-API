using Microsoft.EntityFrameworkCore;
using apiApp.Interfaces;
using apiApp.Models;
using apiApp.Data;
using apiApp.DTOs;
using AutoMapper;

namespace apiApp.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookDto>?> GetBooksAsync()
        {
            var books = await _context.Books.ToListAsync();

            if (!books.Any())
                return null;

            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return null;

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> BookExistsAsync(int id)
        {
            return await _context.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<BookDto> CreateBookAsync(BookCreateDto bookCreateDto)
        {
            var book = _mapper.Map<Book>(bookCreateDto);

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto?> UpdateBookAsync(int id, BookUpdateDto bookUpdateDto)
        {
            var book = await _context.Books.FindAsync(id);

            book.Title = bookUpdateDto.Title ?? book.Title;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}