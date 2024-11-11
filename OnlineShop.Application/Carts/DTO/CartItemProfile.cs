using AutoMapper;
using OnlineShop.Application.Carts.Command.AddToCart;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Carts.DTO
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<AddToCartCommand, CartItem>();
            CreateMap<CartItem, CartItemDTO>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductVariant.Product.Id))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductVariant.Product.Name))
            .ForMember(dest => dest.ProductVariantId, opt => opt.MapFrom(src => src.ProductVariant.Id))
            .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.ProductVariant.Attributes))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductVariant.Price))
            .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.ProductVariant.SalePrice))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            //Map the first image of the product variant to the image of the cart item
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ProductVariant.ProductImages.FirstOrDefault().ImageUrl));
        }
    }
}
