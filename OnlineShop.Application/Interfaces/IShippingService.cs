using OnlineShop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IShippingService
    {
        Task<ShippingDTO> GetShippingByOrderIdAsync(int orderId);
        Task AddShippingAsync(ShippingDTO shippingDto);
        Task UpdateShippingStatusAsync(int shippingId, string status);
    }
}
