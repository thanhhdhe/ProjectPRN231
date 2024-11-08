using AutoMapper;
using OnlineShop.Application.Products.Command.CreateProduct;
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
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
