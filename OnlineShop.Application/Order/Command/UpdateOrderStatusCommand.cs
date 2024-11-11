using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.Command
{

public class UpdateOrderStatusCommand : IRequest<Unit>
    {
    public int OrderId { get; set; }
    public string NewStatus { get; set; }
}

}
