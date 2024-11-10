using AutoMapper;
using MediatR;
using OnlineShop.Application.Reviews.Command.DeleteReview;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Reviews.Command.UpdateReview
{
    public class UpdateReviewCommandHandler(IReviewRepository reviewRepository,
        IUserContext userContext,
        IMapper mapper) : IRequestHandler<UpdateReviewCommand>
    {
        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await reviewRepository.GetReviewByIdAsync(request.Id);
            if (review == null)
            {
                throw new NotFoundException(nameof(Review), request.Id.ToString());
            }
            var user = userContext.GetCurrentUser();
            if (review.CustomerId != user.Id)
            {
                throw new UnauthorizedAccessException("You can only update your own reviews.");
            }
            mapper.Map(request, review);
            review.UpdatedAt = DateTime.Now;
            await reviewRepository.UpdateReviewAsync(review);
        }
    }
}
