using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineShopDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetSubCategoriesAsync(int parentId)
        {
            return await _context.Categories
                .Where(c => c.ParentId == parentId)
                .ToListAsync();
        }
    }
}
