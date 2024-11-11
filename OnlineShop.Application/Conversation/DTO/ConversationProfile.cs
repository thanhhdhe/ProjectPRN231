using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Conversation.DTO
{
    public class ConversationProfile : Profile
    {
        public ConversationProfile()
        {
            CreateMap<Domain.Entities.Conversation, ConversationDTO>()
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
