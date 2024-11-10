using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Carts.Command.DeleteCartItem
{
    public class DeleteCartItemCommandHandler(ICartRepository cartRepository,
        ICartItemRepository cartItemRepository,
        IProductVariantRepository productVariantRepository,
        IMapper mapper,
        IUserStore<User> userStore,
        IUserContext userContext) : IRequestHandler<DeleteCartItemCommand>
    {
        public async Task Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
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
            var cartItem = await cartItemRepository.GetCartItemByCartIdAndProductVariantIdAsync( cart.Id,request.ProductVariantId);
            if (cartItem == null)
            {
                throw new NotFoundException(nameof(CartItem), request.ProductVariantId.ToString());
            }
            if (cartItem.CartId != cart.Id)
            {
                throw new Exception("Cart item not found");
            }
            await cartItemRepository.DeleteCartItemAsync(cartItem);
        }
    }
}
