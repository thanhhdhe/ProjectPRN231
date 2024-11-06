using MediatR;
using OnlineShop.Application.Products.DTO;
using OnlineShop.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDTO>>
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
