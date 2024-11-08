using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductVariantId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual ProductVariant ProductVariant { get; set; } = null!;
    }
}
