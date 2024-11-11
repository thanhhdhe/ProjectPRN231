using AutoMapper;
using MediatR;
using OnlineShop.Application.Users.DTO;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Users.Queries
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, IEnumerable<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        // Constructor to initialize dependencies
        public GetUserRoleQueryHandler(IUserRepository userRepository, IMapper mapper, IUserContext userContext)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        // Corrected: Handle method now processes GetUserRoleQuery
        public async Task<IEnumerable<string>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            // Check if userContext returns null
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null)
            {
                // Throw exception if user is not authenticated
                throw new UnauthorizedAccessException("User not authenticated.");
            }

            // Get userId from userContext
            var currentUserId = currentUser.Id;

            // Check if userId is valid
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new UnauthorizedAccessException("User ID is invalid.");
            }

            // Fetch user information from repository
            var user = await _userRepository.GetUserByIdAsync(currentUserId);

            // Check if the user exists
            if (user == null)
            {
                // Throw exception if user not found
                throw new NotFoundException(nameof(User), currentUserId);
            }

            // Return user roles
            return currentUser.Roles;
        }
    }

}
