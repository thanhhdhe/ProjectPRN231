using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductImage.Command
{
    public class AddImageCommand : IRequest<int>
    {
        public int VariantId { get; set; }
        public string ImageUrl { get; set; }
    }
}
