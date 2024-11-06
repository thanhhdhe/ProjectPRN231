using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class SkuImage
    {
        public int Id { get; set; }
        public int SkuId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public int? SortOrder { get; set; }

        public virtual Sku Sku { get; set; } = null!;
    }
}
