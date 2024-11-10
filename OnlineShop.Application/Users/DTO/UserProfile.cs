using AutoMapper;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Users.DTO
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserProfileDTO>();
                //.ForMember(dest => dest.DateOfBirth,
                //           opt => opt.MapFrom(src => src.DateOfBirth.HasValue
                //                                      ? DateOnly.FromDateTime(src.DateOfBirth.Value)
                //                                      : (DateOnly?)null));
        }
    }
}
