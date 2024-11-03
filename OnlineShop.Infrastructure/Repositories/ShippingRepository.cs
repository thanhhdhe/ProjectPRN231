using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ShippingRepository : GenericRepository<Shipping>, IShippingRepository
    {
        public ShippingRepository(OnlineShopDbContext context) : base(context) { }

        public async Task<Shipping> GetShippingByOrderIdAsync(int orderId)
        {
            return await _context.Shipping
                .FirstOrDefaultAsync(s => s.OrderId == orderId);
        }
    }
}
