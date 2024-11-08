using OnlineShop.Domain.Constants;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<long> AddAsync(Product productEntity);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long id);
        Task SoftDeleteAsync(int id);
        Task<(IEnumerable<Product>, int)> GetAllMatchingAsync(
        string? searchPhrase,
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        int pageSize,
        int pageNumber,
        string? sortBy,
        SortDirection sortDirection
    );
    }
}
