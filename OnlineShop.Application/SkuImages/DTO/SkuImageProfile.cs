using AutoMapper;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.SkuImages.DTO
{
    public class SkuImageProfile : Profile 
    {
        public SkuImageProfile() {
            CreateMap<SkuImage, SkuImageDTO>();
        }
    }
}
