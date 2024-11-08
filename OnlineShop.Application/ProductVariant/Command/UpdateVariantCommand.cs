using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductVariant.Command
{
    public class UpdateVariantCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
