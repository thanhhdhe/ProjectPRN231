using AutoMapper;
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

namespace OnlineShop.Application.Reviews.Command.CreateReview
{
    public class CreateReviewCommandHandler(IReviewRepository reviewRepository,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<CreateReviewCommand, int>
    {
        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            if (user == null)
            {
                throw new NotFoundException(nameof(User), "Current user not found");
            }

            var review = mapper.Map<Review>(request);
            review.CustomerId = user.Id;
            review.CreatedAt = DateTime.Now;
            review.UpdatedAt = DateTime.Now;
            return await reviewRepository.AddReviewAsync(review);
        }
    }
}
