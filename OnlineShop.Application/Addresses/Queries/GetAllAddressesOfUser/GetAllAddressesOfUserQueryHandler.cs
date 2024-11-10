using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineShop.Application.Addresses.DTO;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Addresses.Queries.GetAllAddressesOfUser
{
    public class GetAllAddressesOfUserQueryHandler(IMediator mediator,
        IAddressRepository addressRepository,
        IUserStore<User> userStore,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<GetAllAddressesOfUserQuery, IEnumerable<AddressDTO>>
    {
        public async Task<IEnumerable<AddressDTO>> Handle(GetAllAddressesOfUserQuery request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);

            if (dbUser == null)
            {
                throw new NotFoundException(nameof(User), user!.Id);
            }
            var addresses = await addressRepository.GetByUserId(user!.Id);
            if (addresses == null) {
                throw new NotFoundException(nameof(Address), user!.Id);
            }
            var result = mapper.Map<IEnumerable<AddressDTO>>(addresses);
            return result;
        }
    }
}
