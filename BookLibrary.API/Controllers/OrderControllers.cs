using BookLibrary.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderControllers : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderControllers(IOrderService orderService) => _orderService = orderService;

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook(long userId, long bookId)
        {
            var order = await _orderService.ReserveBookAsync(userId, bookId);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpPost("return/{orderId}")]
        public async Task<IActionResult> ReturnBook(long orderId, [FromQuery] int? rating = null)
        {
            try
            {
                var order = await _orderService.ReturnBookAsync(orderId, rating);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(long id)
        {
            return NotFound();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserOrders(long userId)
        {
            var orders = await _orderService.GetUserOrdersAsync(userId);
            return Ok(orders);
        }
    }
}
