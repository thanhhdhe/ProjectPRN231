using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Users.Command.AssignUserRole
{
    public class AssignUserRoleCommandHandler(UserManager<User> _userManager,
        RoleManager<IdentityRole> _roleManager
        ) : IRequestHandler<AssignUserRoleCommand>
    {
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UserEmail)
                ?? throw new NotFoundException(nameof(User), request.UserEmail);
            var role = await _roleManager.FindByNameAsync(request.RoleName)
                ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);
            await _userManager.AddToRoleAsync(user, role.Name!);
        }
    }
}
