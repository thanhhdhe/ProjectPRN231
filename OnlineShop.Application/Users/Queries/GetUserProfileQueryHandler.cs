using AutoMapper;
using MediatR;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Application.Users.DTO;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Users.Queries
{
    public class GetUserProfileQueryHandler(IUserRepository _userRepository,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<GetUserProfileQuery, UserProfileDTO>
    {
        public async Task<UserProfileDTO> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = userContext.GetCurrentUser().Id;
            var user = await _userRepository.GetUserByIdAsync(currentUserId);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), user!.Id);
            }
            var userProfileDTO = mapper.Map<UserProfileDTO>(user);
            return userProfileDTO;
        }
    }
}
