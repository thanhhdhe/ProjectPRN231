using AutoMapper;
using MediatR;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Application.Users.DTO;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Users.Queries
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        // Constructor để khởi tạo các dependency
        public GetUserProfileQueryHandler(IUserRepository userRepository, IMapper mapper, IUserContext userContext)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<UserProfileDTO> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Kiểm tra xem userContext có trả về null không
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null)
            {
                // Ném ngoại lệ nếu không tìm thấy thông tin người dùng
                throw new UnauthorizedAccessException("User not authenticated.");
            }

            // Lấy userId từ user context
            var currentUserId = currentUser.Id;

            // Kiểm tra xem currentUserId có hợp lệ không
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new UnauthorizedAccessException("User ID is invalid.");
            }

            // Lấy thông tin user từ repository
            var user = await _userRepository.GetUserByIdAsync(currentUserId);

            // Kiểm tra xem user có tồn tại không
            if (user == null)
            {
                // Ném exception nếu không tìm thấy user
                throw new NotFoundException(nameof(User), currentUserId);
            }

            // Map đối tượng user sang UserProfileDTO
            var userProfileDTO = _mapper.Map<UserProfileDTO>(user);

            return userProfileDTO;
        }
    }
}
