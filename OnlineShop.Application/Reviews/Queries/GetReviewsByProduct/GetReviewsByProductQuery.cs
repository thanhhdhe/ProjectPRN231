using MediatR;
using OnlineShop.Application.Reviews.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Reviews.Queries.GetReviewsByProduct
{
    public class GetReviewsByProductQuery : IRequest<IEnumerable<ReviewDTO>>
    {
        public int ProductId { get; set; }
    }
}
