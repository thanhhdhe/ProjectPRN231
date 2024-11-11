using MediatR;
using OnlineShop.Application.OrderDetail.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.Command
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string ReceiverName { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string AddressDetail { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ward { get; set; }

        [Required]
        [MaxLength(100)]
        public string District { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
