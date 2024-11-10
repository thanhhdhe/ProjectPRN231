using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.DTO
{
    public class OrderProfile : Profile
    {
        public OrderProfile() {
            CreateMap<Domain.Entities.Order, OrderDTO>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId)) // Chuyển CustomerId sang UserId
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)) // Đảm bảo ánh xạ Status chính xác
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt)) // Ánh xạ CreatedAt
                    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt)); // Ánh xạ UpdatedAt
        }
        
    }
}
