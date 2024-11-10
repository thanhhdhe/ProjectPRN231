using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Addresses.Command.UpdateAddress
{
    public class UpdateAddressCommand : IRequest
    {
        public int Id { get; set; }
        public string ReceiverName { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressDetail { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string City { get; set; }
    }
}
