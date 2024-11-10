using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Reviews.Command.DeleteReview
{
    public class DeleteReviewCommand : IRequest
    {
        public int Id { get; set; }
    }
}
