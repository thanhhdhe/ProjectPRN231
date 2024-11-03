using AutoMapper;
using OnlineShop.Application.DTO;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.Repositories;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.Application.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;

        public ShippingService(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<ShippingDTO> GetShippingByOrderIdAsync(int orderId)
        {
            var shipping = await _shippingRepository.FindAsync(s => s.OrderId == orderId);
            return _mapper.Map<ShippingDTO>(shipping.FirstOrDefault());
        }

        public async Task AddShippingAsync(ShippingDTO shippingDto)
        {
            var shipping = _mapper.Map<Shipping>(shippingDto);
            await _shippingRepository.AddAsync(shipping);
            await _shippingRepository.SaveChangesAsync();
        }

        public async Task UpdateShippingStatusAsync(int shippingId, string status)
        {
            var shipping = await _shippingRepository.GetByIdAsync(shippingId);
            if (shipping == null) throw new Exception("Shipping not found");

            shipping.Status = status;
            await _shippingRepository.SaveChangesAsync();
        }
    }
}
