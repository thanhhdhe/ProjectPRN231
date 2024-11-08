using AutoMapper;
using MediatR;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.ProductVariant.DTO;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductVariant.Queries
{
    // GetVariantByIdHandler.cs
    public class GetVariantByIdHandler : IRequestHandler<GetVariantByIdQuery, ProductVariantDTO>
    {
        private readonly IProductVariantRepository _variantRepository;
        private readonly IMapper _mapper;

        public GetVariantByIdHandler(IProductVariantRepository variantRepository, IMapper mapper)
        {
            _variantRepository = variantRepository;
            _mapper = mapper;
        }

        public async Task<ProductVariantDTO> Handle(GetVariantByIdQuery request, CancellationToken cancellationToken)
        {
            var variant = await _variantRepository.GetByIdAsync(request.Id);
            if (variant == null)
            {
                throw new NotFoundException("Variant not found");
            }

            return _mapper.Map<ProductVariantDTO>(variant);
        }
    }

}
