using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface ICartItemRepository
    {
        Task<int> AddCartItemAsync(CartItem cartItem);
        Task DeleteCartItemAsync(CartItem cartItem);
        Task<CartItem> GetCartItemByCartIdAndProductVariantIdAsync(int id, int productVariantId);
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int id);
        Task UpdateCartItemAsync(CartItem cartItemInCart);
    }
}
