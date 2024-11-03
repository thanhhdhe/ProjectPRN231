using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }  // Enum: 'Pending', 'Shipped', 'Delivered', 'Cancelled'
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }

        // Relationships
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }
        public Shipping Shipping { get; set; }
    }

}
