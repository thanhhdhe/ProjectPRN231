using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Carts.Command.DeleteCartItem
{
    public class DeleteCartItemCommand(int id) : IRequest
    {
        public int ProductVariantId { get; } = id;
    }
}
