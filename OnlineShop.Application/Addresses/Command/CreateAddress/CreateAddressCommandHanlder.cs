using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Addresses.Command.CreateAddress
{
    public class CreateAddressCommandHanlder(IAddressRepository addressRepository,
        IMapper mapper,
        IUserStore<User> userStore,
        IUserContext userContext) : IRequestHandler<CreateAddressCommand, int>
    {
        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);

            if (dbUser == null)
            {
                throw new NotFoundException(nameof(User), user!.Id);
            }
            var address = mapper.Map<Address>(request);
            address.CustomerId = user.Id;
            return await addressRepository.AddAddressAsync(address);
        }
    }
}
