using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class PaymentDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal? Amount { get; set; }
        public string? Provider { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
