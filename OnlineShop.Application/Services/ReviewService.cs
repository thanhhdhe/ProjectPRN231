using AutoMapper;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviewsByProductIdAsync(int productId)
        {
            var reviews = await _reviewRepository.FindAsync(r => r.ProductId == productId);
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task AddReviewAsync(ReviewDTO reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);
            if (review == null) throw new Exception("Review not found");

            _reviewRepository.Remove(review);
            await _reviewRepository.SaveChangesAsync();
        }
    }
}
