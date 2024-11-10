using AutoMapper;
using MediatR;
using OnlineShop.Application.Users;
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
        private readonly IUserContext _userContext;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IUserContext userContext)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Get current user info from token
            var currentUser = _userContext.GetCurrentUser();
            var userId = currentUser.Id;  // UserId from the token

            // You can also use roles here if needed
            var roles = currentUser.Roles;  // Extract roles from the token

            var order = new Domain.Entities.Order
            {
                Id = int.Parse(userId), // Assuming userId is a string; change if it's another type
                TotalAmount = request.TotalAmount,
                Status = "Pending",  // Set initial status as Pending
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Map OrderItems from the DTO
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
