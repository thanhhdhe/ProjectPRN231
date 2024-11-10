using MediatR;
using OnlineShop.Application.Addresses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Addresses.Queries.GetAllAddressesOfUser
{
    public class GetAllAddressesOfUserQuery : IRequest<IEnumerable<AddressDTO>>
    {
    }
}
