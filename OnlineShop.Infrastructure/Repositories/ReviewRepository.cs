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
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(OnlineShopDbContext context) : base(context) { }

        public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId)
        {
            return await _context.Reviews
                .Where(r => r.ProductId == productId)
                .ToListAsync();
        }
    }
}
