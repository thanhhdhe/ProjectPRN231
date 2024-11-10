using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<int> AddReviewAsync(Review review);
        Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId);
        Task<Review> GetReviewByIdAsync(int reviewId);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(Review review);
    }
}
