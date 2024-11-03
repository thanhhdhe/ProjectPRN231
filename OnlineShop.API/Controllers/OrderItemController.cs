using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var orderItems = await _orderItemService.GetOrderItemsByOrderIdAsync(orderId);
            return Ok(orderItems);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderItemDTO orderItemDto)
        {
            await _orderItemService.AddOrderItemAsync(orderItemDto);
            return CreatedAtAction(nameof(GetByOrderId), new { orderId = orderItemDto.OrderId }, orderItemDto);
        }
    }
}
