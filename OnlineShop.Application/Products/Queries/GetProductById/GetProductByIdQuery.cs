using MediatR;
using OnlineShop.Application.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public long Id { get; init; }
        public GetProductByIdQuery(long id)
        {
            Id = id;
        }
    }
}
