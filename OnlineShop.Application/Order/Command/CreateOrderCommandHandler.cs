using AutoMapper;
using MediatR;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using System;
using System.Linq;
using System.Threading;
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
            // Lấy thông tin người dùng hiện tại từ token
            var currentUser = _userContext.GetCurrentUser();
            var userId = currentUser.Id;

            // Tính `TotalAmount` từ danh sách `Items`
            var totalAmount = request.Items.Sum(item => item.Price * item.Quantity);

            var order = new Domain.Entities.Order
            {
                CustomerId = userId, 
                TotalAmount = totalAmount,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                OrderItems = request.Items.Select(item => new OrderItem
                {
                    ProductVariantId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            return await _orderRepository.CreateAsync(order);
        }
    }
}
