using AutoMapper;
using OnlineShop.Application.Products.Command.CreateProduct;
using OnlineShop.Application.ProductVariant.DTO;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.DTO
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.ModelNumber, opt => opt.MapFrom(src => src.ModelNumber))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Specifications, opt => opt.MapFrom(src => src.Specifications))
                .ForMember(dest => dest.Warranty, opt => opt.MapFrom(src => src.Warranty))
                .ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductVariantDTOs, opt => opt.MapFrom(src => src.ProductVariants))
                //Mapp Price of the first ProductVariant to Price of ProductDTO
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductVariants.FirstOrDefault().Price))
                .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.ProductVariants.FirstOrDefault().SalePrice));


        }
    }
}
