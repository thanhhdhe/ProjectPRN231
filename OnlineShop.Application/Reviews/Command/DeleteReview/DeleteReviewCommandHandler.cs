using MediatR;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Reviews.Command.DeleteReview
{
    public class DeleteReviewCommandHandler(IReviewRepository reviewRepository,
        IUserContext userContext) : IRequestHandler<DeleteReviewCommand>
    {
        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await reviewRepository.GetReviewByIdAsync(request.Id);
            if (review == null)
            {
                throw new NotFoundException(nameof(Review), request.Id.ToString());
            }
            var user = userContext.GetCurrentUser();
            if (review.CustomerId != user.Id)
            {
                throw new UnauthorizedAccessException("You can only delete your own reviews.");
            }
            await reviewRepository.DeleteReviewAsync(review);
        }
    }
}
