using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }  // Enum: 'Credit Card', 'PayPal', 'Bank Transfer', 'COD'
        public string Status { get; set; }  // Enum: 'Pending', 'Completed', 'Failed'

        // Relationships
        public Order Order { get; set; }
    }

}
