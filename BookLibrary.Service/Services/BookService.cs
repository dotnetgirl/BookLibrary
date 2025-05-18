using BookLibrary.DAL.DbContexts;
using BookLibrary.Domain.Models;
using BookLibrary.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookLibrary.Service.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
            => await _context.Books.ToListAsync();

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(long id, Book updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            book.Title = updatedBook.Title;
            book.DailyPrice = updatedBook.DailyPrice;
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
