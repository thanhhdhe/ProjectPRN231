using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Warranties = new HashSet<Warranty>();
        }

        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int SkuId { get; set; }
        public decimal? ListPrice { get; set; }
        public int? QuantityOrder { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Sku Sku { get; set; } = null!;
        public virtual ICollection<Warranty> Warranties { get; set; }
    }
}
