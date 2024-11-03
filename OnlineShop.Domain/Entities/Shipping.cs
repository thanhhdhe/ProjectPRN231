using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Shipping
    {
        public int ShippingId { get; set; }
        public int OrderId { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }  // Enum: 'Pending', 'Shipped', 'Delivered'

        // Relationships
        public Order Order { get; set; }
    }

}
