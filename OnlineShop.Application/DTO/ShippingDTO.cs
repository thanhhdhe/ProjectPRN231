using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DTO
{
    public class ShippingDTO
    {
        public int ShippingId { get; set; }
        public int OrderId { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }  // 'Pending', 'Shipped', 'Delivered'
    }
}
