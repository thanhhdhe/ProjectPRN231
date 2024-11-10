using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Users.Command.UpdateUserDetails;
using OnlineShop.Application.Users;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Exceptions;

public class UpdateUserDetailsCommandHandler(IUserContext userContext,
    IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);

        if (dbUser == null)
        {
            throw new NotFoundException(nameof(User), user!.Id);
        }

        dbUser.Avatar = request.Avatar;
        dbUser.FirstName = request.FirstName;
        dbUser.LastName = request.LastName;
        dbUser.DateOfBirth = request.DateOfBirth;

        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}

