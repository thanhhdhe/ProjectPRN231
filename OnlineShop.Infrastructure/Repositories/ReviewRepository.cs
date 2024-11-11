using Microsoft.EntityFrameworkCore;
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
    public class ReviewRepository : IReviewRepository
    {
        private readonly OnlineShopDBContext _context;

        public ReviewRepository(OnlineShopDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review.Id;
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId)
        {
            return await _context.Reviews
                .Include(r => r.Customer)
                .Where(r => r.ProductId == productId).ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await _context.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
        }

        public async Task UpdateReviewAsync(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
