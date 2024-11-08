using AutoMapper;
using MediatR;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.ProductImage.DTO;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductImage.Queries
{
    public class GetProductImageByIdHandler : IRequestHandler<GetProductImageByIdQuery, ProductImageDTO>
    {
        private readonly IProductImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetProductImageByIdHandler(IProductImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<ProductImageDTO> Handle(GetProductImageByIdQuery request, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetByIdAsync(request.Id);
            if (image == null)
            {
                throw new NotFoundException("Product image not found");
            }

            return _mapper.Map<ProductImageDTO>(image);
        }
    }

}
