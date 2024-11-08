using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Repositories;

namespace OnlineShop.Application.ProductVariant.Command
{
    public class DeleteVariantHandler : IRequestHandler<DeleteVariantCommand, Unit>
    {
        private readonly IProductVariantRepository _variantRepository;

        public DeleteVariantHandler(IProductVariantRepository variantRepository)
        {
            _variantRepository = variantRepository;
        }

        public async Task<Unit> Handle(DeleteVariantCommand request, CancellationToken cancellationToken)
        {
            await _variantRepository.SoftDeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
