using MediatR;
using System;

namespace OnlineShop.Application.ProductVariant.Command
{
    public class CreateVariantCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string Attributes { get; set; }  
    }
}
