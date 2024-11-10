using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.Carts.DTO;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Carts.Queries.GetCartItems
{
    public class GetCartItemsQueryHandler(IMediator mediator,
        ICartRepository cartRepository,
        ICartItemRepository cartItemRepository,
        IUserStore<User> userStore,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<GetCartItemsQuery, IEnumerable<CartItemDTO>>
    {
        public async Task<IEnumerable<CartItemDTO>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            if (request == null) {
                throw new ArgumentNullException(nameof(request));
            }
            var user = userContext.GetCurrentUser();
            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
            if (dbUser == null)
            {
                throw new NotFoundException(nameof(User), user!.Id);
            }
            var cart = await cartRepository.GetCartByUserIdAsync(user.Id);
            if (cart == null)
            {
                throw new NotFoundException(nameof(Cart), user.Id);
            }
            var cartItems = await cartItemRepository.GetCartItemsByCartIdAsync(cart.Id);
            if (cartItems == null)
            {
                throw new NotFoundException(nameof(CartItem), cart.Id.ToString());
            }
            var result = mapper.Map<IEnumerable<CartItemDTO>>(cartItems);
            return result;
        }
    }
}
