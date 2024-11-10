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
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(int userId, bool isAdmin)
        {
            if (isAdmin)
            {
                return await _context.Orders.ToListAsync(); // Admin can see all orders
            }
            return await _context.Orders.Where(o => o.CustomerId == userId.ToString()).ToListAsync(); // Customer can see only their orders
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                                 .Include(o => o.OrderItems)
                                 .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task CancelOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                order.Status = "Canceled"; // Update status to "Canceled"
                await _context.SaveChangesAsync();
            }
        }
    }

}
