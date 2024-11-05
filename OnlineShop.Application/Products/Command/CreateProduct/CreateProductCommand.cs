using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<long>
    {
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public byte ProductStatus { get; set; } = 0;  // 0: out of stock, 1: in stock
        public string ProductAttrs { get; set; }  // JSON attributes
        public bool IsDeleted { get; set; } = false;
        public int Sort { get; set; } = 0;
    }
}
