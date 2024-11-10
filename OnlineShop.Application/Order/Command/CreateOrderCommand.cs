using MediatR;
using OnlineShop.Application.OrderDetail.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.Command
{
    public class CreateOrderCommand : IRequest<int>
    {
        public decimal TotalAmount { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
