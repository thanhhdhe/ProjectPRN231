using AutoMapper;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _orderRepository.FindAsync(o => o.UserId == userId);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<int> CreateOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
            return order.OrderId;
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) throw new Exception("Order not found");

            order.Status = status;
            await _orderRepository.SaveChangesAsync();
        }
    }
}
