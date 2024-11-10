using AutoMapper;
using MediatR;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Addresses.Command.DeleteAddress
{
    public class DeleteAddressCommandHandler(IAddressRepository addressRepository,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<DeleteAddressCommand>
    {
        public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await addressRepository.GetAddressByIdAsync(request.Id);
            if (address == null)
            {
                throw new Exception("Address not found");
            }
            var user = userContext.GetCurrentUser();
            // check if the address belongs to the user
            if (address.CustomerId != user.Id)
            {
                throw new Exception("Address not found");
            }
            address.IsDeleted = true;
            await addressRepository.UpdateAddressAsync(address);
        }
    }
}
