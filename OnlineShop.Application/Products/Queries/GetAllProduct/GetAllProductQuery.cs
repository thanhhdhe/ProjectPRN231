using MediatR;
using OnlineShop.Application.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
