using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
    public class ProductVariant
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string SKU { get; set; }


        [Column(TypeName = "decimal(18, 0)")]
        public decimal? SalePrice { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }

        public int Quantity { get; set; }

        public string Attributes { get; set; } // Có thể tạo bảng riêng nếu cần

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        // Navigation properties
        public Product Product { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
