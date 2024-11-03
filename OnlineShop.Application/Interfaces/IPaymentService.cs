using OnlineShop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDTO> GetPaymentByOrderIdAsync(int orderId);
        Task AddPaymentAsync(PaymentDTO paymentDto);
        Task UpdatePaymentStatusAsync(int paymentId, string status);
    }
}
