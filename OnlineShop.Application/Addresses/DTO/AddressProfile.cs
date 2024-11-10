using AutoMapper;
using OnlineShop.Application.Addresses.Command.CreateAddress;
using OnlineShop.Application.Addresses.Command.UpdateAddress;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Addresses.DTO
{
    public class AddressProfile:Profile
    {
        public AddressProfile()
        {
            CreateMap<UpdateAddressCommand, Address>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.Now));
            CreateMap<CreateAddressCommand, Address>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => false));
            CreateMap<Address, AddressDTO>();
        }
    }
}
