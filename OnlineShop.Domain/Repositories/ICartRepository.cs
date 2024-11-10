using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface ICartRepository
    {
        Task CreateCartForUserAsync(string id);
        Task<Cart> GetCartByUserIdAsync(string id);
    }
}
