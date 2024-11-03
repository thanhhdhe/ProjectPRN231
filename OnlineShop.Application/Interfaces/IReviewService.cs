using OnlineShop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetReviewsByProductIdAsync(int productId);
        Task AddReviewAsync(ReviewDTO reviewDto);
        Task DeleteReviewAsync(int reviewId);
    }
}
