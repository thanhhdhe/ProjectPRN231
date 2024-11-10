using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<int> CreateAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync(int userId, bool isAdmin);
        Task<Order?> GetByIdAsync(int id);
        Task CancelOrderAsync(int id);
    }

}
