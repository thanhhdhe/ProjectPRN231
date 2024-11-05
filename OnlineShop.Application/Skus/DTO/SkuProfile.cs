using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Skus.DTO
{
    public class SkuProfile : Profile 
    {
        public SkuProfile()
        {
            CreateMap<Sku, SkuDTO>();
        }
    }
}
