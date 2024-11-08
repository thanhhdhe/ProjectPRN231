using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Constants;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return productEntity.Id;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products
                .ToListAsync();
            return products;
        }

        public async Task<(IEnumerable<Product>, int)> GetAllMatchingAsync(
    string? searchPhrase,
    int? categoryId,
    decimal? minPrice,
    decimal? maxPrice,
    int pageSize,
    int pageNumber,
    string? sortBy,
    SortDirection sortDirection
)
        {
            var query = _context.Products.Include(p => p.ProductVariants)
                                         .Where(p => p.IsDeleted != true);

            // Apply search filters on Name and Description
            if (!string.IsNullOrEmpty(searchPhrase))
            {
                query = query.Where(p => p.Name.Contains(searchPhrase) || p.Description.Contains(searchPhrase));
            }

            // Apply category filter
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            // Apply price filters based on ProductVariants
            if (minPrice.HasValue || maxPrice.HasValue)
            {
                query = query.Where(p => p.ProductVariants
                                          .Any(v =>
                                                (!minPrice.HasValue || v.SalePrice >= minPrice) &&
                                                (!maxPrice.HasValue || v.SalePrice <= maxPrice)));
            }

            // Sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortDirection == SortDirection.Ascending
                    ? query.OrderBy(p => EF.Property<object>(p, sortBy))
                    : query.OrderByDescending(p => EF.Property<object>(p, sortBy));
            }

            // Get total count for pagination
            var totalCount = await query.CountAsync();

            // Paginate the results
            var products = await query.Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();

            return (products, totalCount);
        }

        public async Task SoftDeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            var products = await _context.Products
                .FirstOrDefaultAsync(y =>
                y.Id == id);
            return products;
        }

        public Task<(IEnumerable<Product>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
        {
            throw new NotImplementedException();
        }
    }
}
