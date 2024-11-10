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

namespace OnlineShop.Application.Carts.Command.AddToCart
{
    public class AddToCartCommandHandler(ICartRepository cartRepository,
        ICartItemRepository cartItemRepository,
        IProductVariantRepository productVariantRepository,
        IMapper mapper,
        IUserStore<User> userStore,
        IUserContext userContext) : IRequestHandler<AddToCartCommand, int>
    {
        public async Task<int> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
            if (dbUser == null) {
                throw new NotFoundException(nameof(User), user!.Id);
            }
            var cart = await cartRepository.GetCartByUserIdAsync(user.Id);
            if (cart == null)
            {
                await cartRepository.CreateCartForUserAsync(user.Id);
                cart = await cartRepository.GetCartByUserIdAsync(user.Id);
            }
            //check product variant is valid
            var productVariant = await productVariantRepository.GetByIdAsync(request.ProductVariantId);
            if (productVariant == null)
            {
                throw new NotFoundException(nameof(ProductVariant), request.ProductVariantId.ToString());
            }
            if (productVariant.Quantity < request.Quantity)
            {
                throw new Exception("Product out of stock");
            }
            //check product varient is in cart
            var cartItemInCart = await cartItemRepository.GetCartItemByCartIdAndProductVariantIdAsync(cart.Id, request.ProductVariantId);
            if (cartItemInCart != null)
            {
                cartItemInCart.Quantity += request.Quantity;
                cartItemInCart.UpdatedAt = DateTime.Now;
                await cartItemRepository.UpdateCartItemAsync(cartItemInCart);
                return cartItemInCart.Id;
            }
            var cartItem = mapper.Map<CartItem>(request);
            cartItem.CartId = cart.Id;
            return await cartItemRepository.AddCartItemAsync(cartItem);
        }
    }
}
