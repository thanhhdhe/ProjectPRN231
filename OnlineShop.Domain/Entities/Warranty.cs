using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Warranty
    {
        public int WarrantyId { get; set; }
        public int? OrderDetailId { get; set; }
        public int? SkuId { get; set; }
        public int? CustomerId { get; set; }
        public string? ImageProduct { get; set; }
        public string? ProductStatus { get; set; }
        public DateTime? WarrantyDate { get; set; }
        public string? WarrantyStatus { get; set; }
        public int? WarrantyQuantity { get; set; }
        public string? ProductStatusAdmin { get; set; }
        public string? ImageProductAdmin { get; set; }
        public DateTime? WarrantyDateAdmin { get; set; }
        public string? Status { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual OrderDetail? OrderDetail { get; set; }
        public virtual Sku? Sku { get; set; }
    }
}
