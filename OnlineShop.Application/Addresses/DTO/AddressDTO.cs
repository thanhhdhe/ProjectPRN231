using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Addresses.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string ReceiverName { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressDetail { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
