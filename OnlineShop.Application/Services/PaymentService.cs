using AutoMapper;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> GetPaymentByOrderIdAsync(int orderId)
        {
            var payment = await _paymentRepository.FindAsync(p => p.OrderId == orderId);
            return _mapper.Map<PaymentDTO>(payment.FirstOrDefault());
        }

        public async Task AddPaymentAsync(PaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.AddAsync(payment);
            await _paymentRepository.SaveChangesAsync();
        }

        public async Task UpdatePaymentStatusAsync(int paymentId, string status)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null) throw new Exception("Payment not found");

            payment.Status = status;
            await _paymentRepository.SaveChangesAsync();
        }
    }
}
