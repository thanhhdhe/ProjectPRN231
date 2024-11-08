using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<Category?> GetByIdAsync(int id);
        Task UpdateAsync(Category category);
        Task SoftDeleteAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
    }

}
