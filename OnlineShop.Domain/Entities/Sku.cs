using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Sku
    {
        public Sku()
        {
            OrderDetails = new HashSet<OrderDetail>();
            SkuImages = new HashSet<SkuImage>();
            Variants = new HashSet<Variant>();
            Warranties = new HashSet<Warranty>();
        }

        public int SkuId { get; set; }
        public string SkuNo { get; set; } = null!;
        public string? SkuName { get; set; }
        public string? SkuDescription { get; set; }
        public byte? SkuType { get; set; }
        public byte? Status { get; set; }
        public int? Sort { get; set; }
        public int? SkuStock { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal? PromotionalPrice { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<SkuImage> SkuImages { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
        public virtual ICollection<Warranty> Warranties { get; set; }
    }
}
