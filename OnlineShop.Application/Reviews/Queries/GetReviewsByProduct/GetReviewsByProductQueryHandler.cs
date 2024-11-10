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
    public class GetReviewsByProductQueryHandler(IReviewRepository reviewRepository,
        IMapper mapper) : IRequestHandler<GetReviewsByProductQuery, IEnumerable<ReviewDTO>>
    {
        public async Task<IEnumerable<ReviewDTO>> Handle(GetReviewsByProductQuery request, CancellationToken cancellationToken)
        {
            var reviews = await reviewRepository.GetReviewsByProductIdAsync(request.ProductId);
            return mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }
    }
}
