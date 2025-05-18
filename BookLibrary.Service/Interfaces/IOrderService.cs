using BookLibrary.Domain.Models;

namespace BookLibrary.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> ReserveBookAsync(long userId, long bookId);
        Task<Order> ReturnBookAsync(long orderId, int? rating = null);
        Task<IEnumerable<Order>> GetUserOrdersAsync(long userId);
    }

}
