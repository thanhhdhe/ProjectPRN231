using AutoMapper;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Variants.DTO
{
    public class VariantProfile : Profile
    {
        public VariantProfile()
        {
            CreateMap<Variant, VariantDTO>();
        }
    }
}
