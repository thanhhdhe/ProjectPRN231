using MediatR;
using OnlineShop.Application.Reviews.Command.DeleteReview;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Domain.Repositories;

public class DeleteReviewCommandHandler(IReviewRepository reviewRepository,
        IUserContext userContext) : IRequestHandler<DeleteReviewCommand>
{
    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
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
        return Unit.Value;
    }

    Task IRequestHandler<DeleteReviewCommand>.Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}