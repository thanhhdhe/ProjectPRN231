using MediatR;
using OnlineShop.Application.Carts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Carts.Queries.GetCartItems
{
    public class GetCartItemsQuery : IRequest<IEnumerable<CartItemDTO>>
    {
    }
}
