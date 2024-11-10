using AutoMapper;
using OnlineShop.Application.OrderDetail.DTO;
using OnlineShop.Domain.Entities;
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

            CreateMap<Domain.Entities.Order, OrderDetailDTO>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductVariantId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
        
    }
}
