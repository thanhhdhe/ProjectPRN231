using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductVariant.Command
{
    public class CreateVariantHandler : IRequestHandler<CreateVariantCommand, int>
    {
        private readonly IProductVariantRepository _variantRepository;

        public CreateVariantHandler(IProductVariantRepository variantRepository)
        {
            _variantRepository = variantRepository;
        }

        public async Task<int> Handle(CreateVariantCommand request, CancellationToken cancellationToken)
        {
            var variant = new Domain.Entities.ProductVariant
            {
                ProductId = request.ProductId,
                SKU = request.Sku,
                Price = request.Price,
                Attributes = request.Attributes  // Gán giá trị Attributes từ request
            };

            await _variantRepository.AddAsync(variant);

            // Trả về ID của variant vừa được tạo
            return variant.Id;
        }
    }
}
