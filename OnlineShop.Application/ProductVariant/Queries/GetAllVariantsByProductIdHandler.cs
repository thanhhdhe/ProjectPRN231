using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.ProductVariant.DTO;
using OnlineShop.Domain.Repositories;

namespace OnlineShop.Application.ProductVariant.Queries
{
    public class GetAllVariantsByProductIdHandler : IRequestHandler<GetAllVariantsByProductIdQuery, IEnumerable<ProductVariantDTO>>
    {
        private readonly IProductVariantRepository _variantRepository;
        private readonly IMapper _mapper;

        public GetAllVariantsByProductIdHandler(IProductVariantRepository variantRepository, IMapper mapper)
        {
            _variantRepository = variantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVariantDTO>> Handle(GetAllVariantsByProductIdQuery request, CancellationToken cancellationToken)
        {
            var variants = await _variantRepository.GetByProductIdAsync(request.ProductId);
            return _mapper.Map<IEnumerable<ProductVariantDTO>>(variants);
        }
    }
}
