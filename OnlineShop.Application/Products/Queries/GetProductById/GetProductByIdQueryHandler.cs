using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Products.DTO;
using OnlineShop.Application.Products.Queries.GetAllProduct;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        public readonly IProductRepository _productRepository;
        private readonly ILogger<GetAllProductQueryHandler> _logger;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository productRepository,
            ILogger<GetAllProductQueryHandler> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting product by id");
            var product = await _productRepository.GetByIdAsync(request.Id);
            var productdto = _mapper.Map<ProductDTO>(product);
            return productdto;

        }
    }
}
