using MediatR;
using OnlineShop.Application.Order.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderDTO>>
    {
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
    }

}
