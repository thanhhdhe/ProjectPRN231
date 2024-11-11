using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductVariant.DTO
{
    public class ProductVariantProfile : Profile 
    {
        public ProductVariantProfile() {
            CreateMap<Domain.Entities.ProductVariant, ProductVariantDTO>()
                .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages));
        }
    }
}
