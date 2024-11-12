using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Order.DTO;
using OnlineShop.Application.PaymentService;
using OnlineShop.Application.PaymentService.DTO;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using static OnlineShop.Application.PaymentService.VNPay;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IVNPay _vnpay;
        private readonly IPaymentRepository _pa;

        public PaymentController(IVNPay vnpay, IPaymentRepository paymentRepository)
        {
            _vnpay = vnpay;
            _pa = paymentRepository;
        }

        [HttpPost("create-payment-url")]
        public async Task<IActionResult> CreatePaymentUrl([FromBody] PaymentCreateDTO order)
        {
            string returnUrl = "http://localhost:3000/payment/vnpay-return";
            string paymentUrl = await _vnpay.CreatePaymentUrl(order, returnUrl);
            return Ok(new { paymentUrl });
        }

        [HttpPost("create-payment")]
        public IActionResult CreatePayment([FromBody] OrderDTO order)
        {
            string returnUrl = "http://localhost:3000/payment/vnpay-return";
            string paymentUrl = _vnpay.CreatePayment(order, returnUrl);
            return Ok(new { paymentUrl });
        }
        //Upadate status payment
        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] PaymentCreateDTO paymentDetail)
        {
            // mapping paymentDetail to PaymentDetail entity
            var p = new PaymentDetail
            {
                OrderId = paymentDetail.OrderId,
                Status = paymentDetail.Status,
                Amount = paymentDetail.Amount,
                //CreatedAt = paymentDetail.CreatedAt,
                UpdatedAt = paymentDetail.UpdatedAt
            };
            await _pa.UpdatePaymentAsync(p.OrderId,p.Status);
            return Ok();
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
