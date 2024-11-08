using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common;
using OnlineShop.Application.Products.DTO;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, PagedResult<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var (products, totalCount) = await _productRepository.GetAllMatchingAsync(
                request.SearchPhrase,
                request.CategoryId,
                request.MinPrice,
                request.MaxPrice,
                request.PageSize,
                request.PageNumber,
                request.SortBy,
                request.SortDirection
            );

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return new PagedResult<ProductDTO>(productDTOs, totalCount, request.PageSize, request.PageNumber);
        }
    }

}
