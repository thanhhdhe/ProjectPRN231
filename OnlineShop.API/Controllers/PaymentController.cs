using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Order.DTO;
using OnlineShop.Application.PaymentService;
using OnlineShop.Domain.Entities;
using static OnlineShop.Application.PaymentService.VNPay;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IVNPay _vnpay;

        public PaymentController(IVNPay vnpay)
        {
            _vnpay = vnpay;
        }

        [HttpPost("create-payment-url")]
        public IActionResult CreatePaymentUrl([FromBody] OrderDTO order)
        {
            string returnUrl = "https://yourwebsite.com/payment-result";
            string paymentUrl = _vnpay.CreatePaymentUrl(order, returnUrl);
            return Ok(new { paymentUrl });
        }

        [HttpPost("create-payment")]
        public IActionResult CreatePayment([FromBody] OrderDTO order)
        {
            string returnUrl = "https://yourwebsite.com/payment-result";
            string paymentUrl = _vnpay.CreatePayment(order, returnUrl);
            return Ok(new { paymentUrl });
        }

        [HttpGet("validate-signature")]
        public IActionResult ValidateSignature([FromQuery] string queryString)
        {
            bool isValid = _vnpay.ValidateSignature(queryString, "ADYDJFZ2D6KX1RLSOLCORUETMITPGZVP"); // Pass your secret key here
            return Ok(new { isValid });
        }

        [HttpPost("refund")]
        public async Task<IActionResult> Refund([FromBody] VnpayRefundRequest refundRequest)
        {
            string url = "https://sandbox.vnpayment.vn/refund-api";
            HttpResponseMessage response = await _vnpay.SendRefundRequestAsync(refundRequest, url);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(new { response = responseContent });
            }
            else
            {
                return BadRequest(new { error = "Refund request failed." });
            }
        }
    }
}
