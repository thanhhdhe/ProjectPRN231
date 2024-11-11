using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface IPaymentRepository
    {
        //create & update payment
        Task<int> CreatePaymentAsync(PaymentDetail payment);
        Task<int> UpdatePaymentAsync(int orderId, string status);
    }
}
