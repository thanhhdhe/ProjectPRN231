using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineShopDBContext _context;

        public OrderRepository(OnlineShopDBContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Order order)
        {
            //change quantity of product variant 
            
            _context.Orders.Add(order);
            foreach (var item in order.OrderItems)
            {
                var productVariant = await _context.ProductVariants.FindAsync(item.ProductVariantId);
                productVariant.Quantity -= item.Quantity;
            }
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(string userId, bool isAdmin)
        {
            if (isAdmin)
            {
                return await _context.Orders.ToListAsync(); 
            }
            return await _context.Orders.Where(o => o.CustomerId == userId).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                                 .Include(o => o.OrderItems)
                                 .ThenInclude(oi => oi.ProductVariant)
                                 .ThenInclude(pv => pv.Product)
                                 .ThenInclude(p => p.Category)
                                 .Include(o => o.Customer)
                                 .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task CancelOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                order.Status = "Canceled";
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }

}
