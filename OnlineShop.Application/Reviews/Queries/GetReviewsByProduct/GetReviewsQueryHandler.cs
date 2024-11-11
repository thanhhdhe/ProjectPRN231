using AutoMapper;
using MediatR;
using OnlineShop.Application.Reviews.DTO;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Reviews.Queries.GetReviewsByProduct
{
    public class GetReviewsQueryHandler(IReviewRepository reviewRepository,
        IMapper mapper) : IRequestHandler<GetReviewsQuery, IEnumerable<ReviewDTO>>
    {
        public async Task<IEnumerable<ReviewDTO>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await reviewRepository.GetReviews();
            return mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }
    }
}
