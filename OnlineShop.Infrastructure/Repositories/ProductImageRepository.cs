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
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly OnlineShopDBContext _context;

        public ProductImageRepository(OnlineShopDBContext context)
        {
            _context = context;
        }

        
        public async Task<ProductImage?> GetByIdAsync(int id)
        {
            return await _context.ProductImages.FindAsync(id);
        }
    }
}
