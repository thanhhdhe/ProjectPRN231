using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Variant
    {
        public int Id { get; set; }
        public string AttributeName { get; set; } = null!;
        public string AttributeValue { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public int SkuId { get; set; }

        public virtual Sku Sku { get; set; } = null!;
    }
}
