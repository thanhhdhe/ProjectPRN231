using AutoMapper;
using OnlineShop.Application.ProductVariant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductImage.DTO
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<OnlineShop.Domain.Entities.ProductImage, ProductImageDTO>();
            CreateMap<OnlineShop.Domain.Entities.ProductVariant, ProductVariantDTO>();
        }
    }

}
