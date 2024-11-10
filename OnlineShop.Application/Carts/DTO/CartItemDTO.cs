using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Carts.DTO
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductVariantId { get; set; }
        public string Attributes { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int Quantity { get; set; }
       
    }
}
