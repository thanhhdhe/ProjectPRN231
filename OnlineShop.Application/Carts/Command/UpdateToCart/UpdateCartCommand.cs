using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Carts.Command.UpdateToCart
{
    public class UpdateCartCommand : IRequest<int>
    {
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; }
    }
}
