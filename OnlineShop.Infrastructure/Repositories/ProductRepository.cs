using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDBContext _context;

        public ProductRepository(OnlineShopDBContext context)
        {
            _context = context;
        }

        public async Task<long> AddAsync(Product productEntity)
        {
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
            return productEntity.ProductId;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.Include(x=>x.Skus).ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            var products = await _context.Products.Include(x => x.Skus).FirstOrDefaultAsync(y =>
            y.ProductId == id);
            return products;
        }
    }
}
