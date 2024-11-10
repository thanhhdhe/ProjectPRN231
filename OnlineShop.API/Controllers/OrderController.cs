using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Order.Command;
using OnlineShop.Application.Order.Queries;
using System.Threading.Tasks;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // [POST] /api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);
        }

        // [GET] /api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] bool isAdmin)
        {
            var query = new GetOrdersQuery { UserId = 1, IsAdmin = isAdmin }; // Example userId, adjust as needed
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        // [GET] /api/orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var query = new GetOrderByIdQuery { OrderId = id };
            var orderDetail = await _mediator.Send(query);
            return Ok(orderDetail);
        }

        // [PUT] /api/orders/{id}/cancel
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var command = new CancelOrderCommand { OrderId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
