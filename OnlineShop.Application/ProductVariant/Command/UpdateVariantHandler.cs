using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Repositories;
using OnlineShop.Application.Exceptions;

namespace OnlineShop.Application.ProductVariant.Command
{
    public class UpdateVariantHandler : IRequestHandler<UpdateVariantCommand, Unit>
    {
        private readonly IProductVariantRepository _variantRepository;

        public UpdateVariantHandler(IProductVariantRepository variantRepository)
        {
            _variantRepository = variantRepository;
        }

        public async Task<Unit> Handle(UpdateVariantCommand request, CancellationToken cancellationToken)
        {
            var variant = await _variantRepository.GetByIdAsync(request.Id);
            if (variant == null) throw new NotFoundException("Variant not found");

            variant.SKU = request.Sku;
            variant.Price = request.Price;
            await _variantRepository.UpdateAsync(variant);
            return Unit.Value;
        }
    }
}
