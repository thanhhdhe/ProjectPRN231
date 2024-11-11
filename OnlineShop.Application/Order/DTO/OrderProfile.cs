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
                    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                    .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                    .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.ReceiverName))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                    .ForMember(dest => dest.AddressDetail, opt => opt.MapFrom(src => src.AddressDetail));



            CreateMap<Domain.Entities.Order, OrderDetailDTO>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.ReceiverName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.AddressDetail, opt => opt.MapFrom(src => src.AddressDetail))
            .ForMember(dest => dest.Ward, opt => opt.MapFrom(src => src.Ward))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));


            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductVariantId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductVariant.Product.Name));
        }
        
    }
}
