using BookLibrary.Domain.Models;

namespace BookLibrary.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(long id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<bool> DeleteAsync(long id);
    }

}
