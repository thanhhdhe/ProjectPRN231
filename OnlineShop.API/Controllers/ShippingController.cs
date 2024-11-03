using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var shipping = await _shippingService.GetShippingByOrderIdAsync(orderId);
            if (shipping == null) return NotFound();
            return Ok(shipping);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ShippingDTO shippingDto)
        {
            await _shippingService.AddShippingAsync(shippingDto);
            return CreatedAtAction(nameof(GetByOrderId), new { orderId = shippingDto.OrderId }, shippingDto);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            await _shippingService.UpdateShippingStatusAsync(id, status);
            return NoContent();
        }
    }
}
