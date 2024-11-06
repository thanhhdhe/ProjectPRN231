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
            return productEntity.ProductId;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products
                .Include(p => p.Brand) // Include Brand
                .Include(p => p.Group)
                .Include(p => p.Category)
                .Include(p => p.Skus) // Include Skus
                    .ThenInclude(s => s.SkuImages) // Include Images for each SKU
                .Include(p => p.Skus) // Include Skus
                    .ThenInclude(s => s.Variants) // Include Variants for each SKU
                .ToListAsync();
            return products;
        }

        public async Task<(IEnumerable<Product>, int)> GetAllMatchingAsync(string? searchPhrase,
        int pageSize,
        int pageNumber,
        string? sortBy,
        SortDirection sortDirection)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var baseQuery = _context
                .Products
                .Where(r => searchPhraseLower == null || (r.ProductName.ToLower().Contains(searchPhraseLower)
                                                       || r.ProductDesc.ToLower().Contains(searchPhraseLower)));

            var totalCount = await baseQuery.CountAsync();

            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Product, object>>>
            {
                { nameof(Product.ProductName), r => r.ProductName },
                { nameof(Product.ProductDesc), r => r.ProductDesc },
            };

                var selectedColumn = columnsSelector[sortBy];

                baseQuery = sortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var products = await baseQuery
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Include(p => p.Brand)
                //.Include(p => p.Group)
                .Include(p => p.Category)
                .Include(p => p.Skus)
                    .ThenInclude(s => s.SkuImages)
                .Include(p => p.Skus)
                    .ThenInclude(s => s.Variants)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            var products = await _context.Products
                .Include(p => p.Brand) 
                //.Include(p => p.Group)
                .Include(p => p.Category)
                .Include(p => p.Skus) 
                    .ThenInclude(s => s.SkuImages) 
                .Include(p => p.Skus) 
                    .ThenInclude(s => s.Variants) // Include Variants for each SKU
                .FirstOrDefaultAsync(y =>
            y.ProductId == id);
            return products;
        }
    }
}
