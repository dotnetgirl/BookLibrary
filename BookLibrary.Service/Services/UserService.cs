using BookLibrary.DAL.DbContexts;
using BookLibrary.Domain.Models;
using BookLibrary.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Service.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(long id) =>
            await _context.Users.FindAsync(id);

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
