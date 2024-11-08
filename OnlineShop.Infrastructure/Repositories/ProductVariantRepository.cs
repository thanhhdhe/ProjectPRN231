using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace OnlineShop.Infrastructure.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly OnlineShopDBContext _context;

        public ProductVariantRepository(OnlineShopDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductVariant variant)
        {
            _context.ProductVariants.Add(variant);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductVariant?> GetByIdAsync(int id)
        {
            return await _context.ProductVariants.FindAsync(id);
        }

        public async Task UpdateAsync(ProductVariant variant)
        {
            _context.ProductVariants.Update(variant);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var variant = await _context.ProductVariants.FindAsync(id);
            if (variant != null)
            {
                variant.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductVariant>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductVariants
                                 .Where(v => v.ProductId == productId && v.IsDeleted != true)
                                 .ToListAsync();
        }
    }

}
