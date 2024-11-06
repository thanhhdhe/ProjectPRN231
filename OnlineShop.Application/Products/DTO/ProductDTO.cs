using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities;
using OnlineShop.Application.Skus.DTO;
using System.Text.Json;
using OnlineShop.Application.Groups.DTO;
using OnlineShop.Application.Brands.DTO;
using OnlineShop.Application.Categories.DTO;

namespace OnlineShop.Application.Products.DTO
{
    public class ProductDTO
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Slug { get; set; }
        public GroupDTO? Group { get; set; }
        public BrandDTO? Brand { get; set; }
        public CategoryDTO? Category { get; set; }
        public ICollection<SkuDTO> Skus { get; set; }
    }
}
