using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.ProductVariant.DTO;

namespace OnlineShop.Application.ProductVariant.Queries
{
    public class GetAllVariantsByProductIdQuery : IRequest<IEnumerable<ProductVariantDTO>>
    {
        public int ProductId { get; set; }

        public GetAllVariantsByProductIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
