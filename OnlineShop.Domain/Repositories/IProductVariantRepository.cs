using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface IProductVariantRepository
    {
        Task AddAsync(ProductVariant variant);
        Task<ProductVariant?> GetByIdAsync(int id);
        Task UpdateAsync(ProductVariant variant);
        Task SoftDeleteAsync(int id);
        Task<IEnumerable<ProductVariant>> GetByProductIdAsync(int productId);
    }

}
