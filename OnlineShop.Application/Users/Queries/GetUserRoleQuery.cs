using MediatR;
using OnlineShop.Application.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Users.Queries
{
    public class GetUserRoleQuery : IRequest<IEnumerable<string>>
    {
    }
}
