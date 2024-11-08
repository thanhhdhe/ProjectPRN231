using MediatR;
using OnlineShop.Application.Common;
using OnlineShop.Application.Products.DTO;
using OnlineShop.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<PagedResult<ProductDTO>>
    {
        public string? SearchPhrase { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }

}
