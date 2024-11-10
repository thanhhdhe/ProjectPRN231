using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Carts.Command.AddToCart
{
    public class AddToCartCommand : IRequest<int>
    {
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
