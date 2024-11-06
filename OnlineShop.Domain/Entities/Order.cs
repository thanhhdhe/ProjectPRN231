using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string? NameReceiver { get; set; }
        public string? PhoneReceiver { get; set; }
        public string? AddressReceiver { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Payment { get; set; }
        public string? Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
