using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class ProductVariant
    {
        public ProductVariant()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Sku { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Attributes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
