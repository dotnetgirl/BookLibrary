using BookLibrary.Domain.Models;

namespace BookLibrary.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(long id, Book book);
        Task<bool> DeleteAsync(long id);
    }
}