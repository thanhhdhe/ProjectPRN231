using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.ProductImage.DTO;
namespace OnlineShop.Application.ProductImage.Queries
{
    public class GetProductImageByIdQuery : IRequest<ProductImageDTO>
    {
        public int Id { get; set; }

        public GetProductImageByIdQuery(int id)
        {
            Id = id;
        }
    }

}
