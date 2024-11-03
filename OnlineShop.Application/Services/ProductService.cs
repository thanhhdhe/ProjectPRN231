using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.Repositories;
using AutoMapper;

namespace OnlineShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task AddProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.ProductId);
            if (product == null) throw new Exception("Product not found");

            _mapper.Map(productDto, product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new Exception("Product not found");

            _productRepository.Remove(product);
            await _productRepository.SaveChangesAsync();
        }
    }
}
