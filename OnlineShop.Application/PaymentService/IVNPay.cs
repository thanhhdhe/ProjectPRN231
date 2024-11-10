using OnlineShop.Application.Order.DTO;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShop.Application.PaymentService.VNPay;

namespace OnlineShop.Application.PaymentService
{
    public interface IVNPay
    {
        string CreatePaymentUrl(OrderDTO order, string returnUrl);
        public string CreatePayment(OrderDTO order, string returnUrl);
        bool ValidateSignature(string queryString, string vnp_HashSecret);
        Task<HttpResponseMessage> SendRefundRequestAsync(VnpayRefundRequest request, string url);
        string GenerateSecureHash(VnpayRefundRequest request, string secretKey);
    }
}
