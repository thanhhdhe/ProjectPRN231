using MediatR;
using OnlineShop.Application.ProductVariant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductVariant.Queries
{
    public class GetVariantByIdQuery : IRequest<ProductVariantDTO>
    {
        public int Id { get; set; }

        public GetVariantByIdQuery(int id)
        {
            Id = id;
        }
    }

}
