using OnlineShop.Application.ProductImage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductVariant.DTO
{
    public class ProductVariantDTO
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Attributes { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public ICollection<ProductImageDTO> ProductImages { get; set; }
    }

}
