using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PaymentDTO paymentDto)
        {
            await _paymentService.AddPaymentAsync(paymentDto);
            return CreatedAtAction(nameof(GetByOrderId), new { orderId = paymentDto.OrderId }, paymentDto);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            await _paymentService.UpdatePaymentStatusAsync(id, status);
            return NoContent();
        }
    }
}
