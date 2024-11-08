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

        public async Task<(IEnumerable<Product>, int)> GetAllMatchingAsync(string? searchPhrase,
        int pageSize,
        int pageNumber,
        string? sortBy,
        SortDirection sortDirection)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var baseQuery = _context
                .Products
                .Where(r => searchPhraseLower == null || (r.Name.ToLower().Contains(searchPhraseLower)
                                                       || r.Description.ToLower().Contains(searchPhraseLower)));

            var totalCount = await baseQuery.CountAsync();

            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Product, object>>>
            {
                { nameof(Product.Name), r => r.Name },
                { nameof(Product.Description), r => r.Description },
            };

                var selectedColumn = columnsSelector[sortBy];

                baseQuery = sortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var products = await baseQuery
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            var products = await _context.Products
                .FirstOrDefaultAsync(y =>
                y.Id == id);
            return products;
        }
    }
}
