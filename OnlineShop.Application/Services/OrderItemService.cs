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
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemDTO>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            var orderItems = await _orderItemRepository.FindAsync(oi => oi.OrderId == orderId);
            return _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);
        }

        public async Task AddOrderItemAsync(OrderItemDTO orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _orderItemRepository.AddAsync(orderItem);
            await _orderItemRepository.SaveChangesAsync();
        }
    }
}
