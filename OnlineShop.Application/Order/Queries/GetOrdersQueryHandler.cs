using AutoMapper;
using MediatR;
using OnlineShop.Application.Order.DTO;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.Queries
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper, IUserContext userContext)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            // Get current user info from token
            var currentUser = _userContext.GetCurrentUser();
            var userId = currentUser.Id;
            var roles = currentUser.Roles;  // Get roles from token (if needed)

            var orders = await _orderRepository.GetAllOrdersAsync(userId, roles.Contains("Admin"));
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }
    }
}
