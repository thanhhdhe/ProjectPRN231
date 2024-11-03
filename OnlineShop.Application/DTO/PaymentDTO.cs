using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DTO
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }  // 'Credit Card', 'PayPal', 'Bank Transfer', 'COD'
        public string Status { get; set; }  // 'Pending', 'Completed', 'Failed'
    }
}
