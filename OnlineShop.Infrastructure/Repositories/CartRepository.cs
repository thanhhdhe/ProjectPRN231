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
    public class CartRepository(OnlineShopDBContext _context) : ICartRepository
    {
        public async Task CreateCartForUserAsync(string id)
        {
            var existingCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == id);
            if (existingCart != null)
            {
                return; 
            }

            var cart = new Cart
            {   
                UserId = id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCartByUserIdAsync(string id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == id);
            return cart;
        }
    }
}
