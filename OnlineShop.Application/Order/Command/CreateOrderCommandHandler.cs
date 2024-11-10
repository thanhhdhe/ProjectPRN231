using AutoMapper;
using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.Command
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Entities.Order
            {
                CustomerId = request.UserId.ToString(),
                TotalAmount = request.TotalAmount,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            // Map order items
            foreach (var item in request.Items)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductVariantId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            return await _orderRepository.CreateAsync(order);
        }
    }
}
