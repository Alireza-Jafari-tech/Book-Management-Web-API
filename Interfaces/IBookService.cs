using apiApp.DTOs;
using apiApp.DTOs;
using apiApp.DTOs;
namespace apiApp.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>?> GetBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<bool> BookExistsAsync(int id);
        Task<BookDto> CreateBookAsync(BookCreateDto bookCreateDto);
        Task<BookDto?> UpdateBookAsync(int id, BookUpdateDto bookUpdateDto);
        Task<bool> DeleteBookAsync(int id);
    }
}