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
    public class CartItemRepository(OnlineShopDBContext context) : ICartItemRepository
    {
        public async Task<int> AddCartItemAsync(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
            await context.SaveChangesAsync();
            return cartItem.Id;
        }

        public async Task DeleteCartItemAsync(CartItem cartItem)
        {
            context.CartItems.Remove(cartItem);
            await context.SaveChangesAsync();
        }

        public async Task<CartItem> GetCartItemByCartIdAndProductVariantIdAsync(int id, int productVariantId)
        {
            var cartItem = await context.CartItems
                .Include(ci => ci.ProductVariant)
                .ThenInclude(pv => pv.ProductImages)
                .FirstOrDefaultAsync(ci => ci.CartId == id && ci.ProductVariantId == productVariantId);
            return cartItem;
        }

        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            var cartItem = await context.CartItems
                .Include(ci => ci.ProductVariant)
                .ThenInclude(pv => pv.ProductImages)
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId);
            return cartItem;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int id)
        {
            var cartItems = context.CartItems
                .Include(ci => ci.ProductVariant)
                .ThenInclude(pv => pv.Product)
                .Include(ci => ci.ProductVariant)
                .ThenInclude(pv => pv.ProductImages)
                .Where(ci => ci.CartId == id).ToListAsync();
            return await cartItems;
        }

        public async Task UpdateCartItemAsync(CartItem cartItemInCart)
        {
            context.CartItems.Update(cartItemInCart);
            await context.SaveChangesAsync();
        }
    }
}
