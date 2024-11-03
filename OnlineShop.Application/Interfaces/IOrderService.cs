using OnlineShop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(string userId);
        Task<int> CreateOrderAsync(OrderDTO orderDto);
        Task UpdateOrderStatusAsync(int orderId, string status);
    }
}
