using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Products.DTO;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDTO>>
    {
        public readonly IProductRepository _productRepository;
        private readonly ILogger<GetAllProductQueryHandler> _logger;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IProductRepository productRepository,
            ILogger<GetAllProductQueryHandler> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all products");
            var products = await _productRepository.GetAllAsync();
            var productdtos = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return productdtos;
        }
    }
}
