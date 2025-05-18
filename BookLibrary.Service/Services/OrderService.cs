using BookLibrary.DAL.DbContexts;
using BookLibrary.Domain.Models;
using BookLibrary.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> ReserveBookAsync(long userId, long bookId)
    {
        var order = new Order
        {
            UserId = userId,
            BookId = bookId,
            StartDate = DateTime.UtcNow,
            IsActive = true
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return order;
    }

    public async Task<Order> ReturnBookAsync(long orderId, int? rating = null)
    {
        var order = await _context.Orders
            .Include(o => o.Book)
            .FirstOrDefaultAsync(o => o.Id == orderId && o.IsActive);

        if (order == null) throw new Exception("Order not found or already returned.");

        order.EndDate = DateTime.UtcNow;
        order.FineAmount = CalculateFine(order);
        order.Rating = rating;
        order.IsActive = false;

        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(long userId)
    {
        return await _context.Orders
            .Include(o => o.Book)
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    private decimal CalculateFine(Order order)
    {
        var days = (order.EndDate.Value - order.StartDate).Days;
        int allowedDays = 7;
        int overdueDays = days - allowedDays;

        if (overdueDays <= 0) return 0;

        return overdueDays * (order.Book.DailyPrice * 0.01m); // 1% per overdue day
    }
}

