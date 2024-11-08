using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public int ProductVariantId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ProductVariant ProductVariant { get; set; } = null!;
    }
}
