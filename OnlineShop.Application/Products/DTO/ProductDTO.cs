using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities;
using OnlineShop.Application.Categories.DTO;

namespace OnlineShop.Application.Products.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Brand { get; set; }
        public string? ModelNumber { get; set; }
        public string? Description { get; set; }
        public string? Specifications { get; set; }
        public string? Warranty { get; set; }
        public string? CoverImage { get; set; }
    }
}
