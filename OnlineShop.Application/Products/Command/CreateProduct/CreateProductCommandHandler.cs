using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository,
            ILogger<CreateProductCommandHandler> logger,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Mapping the CreateProductCommand to Product entity
            var productEntity = _mapper.Map<Product>(request);

            // Ensure the created entity is added to the repository and return the ID
            return await _productRepository.AddAsync(productEntity);
        }
    }
}
