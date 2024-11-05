using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        public readonly IProductRepository _productRepository;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository productRepository,
            ILogger<CreateProductCommandHandler> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
            return await _productRepository.AddAsync(productEntity);
        }
    }
}
