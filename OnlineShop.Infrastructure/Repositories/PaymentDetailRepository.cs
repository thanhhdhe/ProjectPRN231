using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class PaymentDetailRepository(OnlineShopDBContext context) : IPaymentRepository
    {
        public async Task<int> CreatePaymentAsync(PaymentDetail payment)
        {
            context.PaymentDetails.Add(payment);
            await context.SaveChangesAsync();
            return payment.Id;
        }

        public async Task<int> UpdatePaymentAsync(int orderId, string status)
        {
            //find payment detail by order id
            var payment = await context.PaymentDetails.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            payment.Status = status;

            context.PaymentDetails.Update(payment);
            await context.SaveChangesAsync();
            return payment.Id;
        }
    }
}
