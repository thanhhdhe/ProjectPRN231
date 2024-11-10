using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Users;
using OnlineShop.Application.Users.Command.AssignUserRole;
using OnlineShop.Application.Users.Command.UnAssignUserRole;
using OnlineShop.Application.Users.Command.UpdateUserDetails;
using OnlineShop.Application.Users.Queries;
using OnlineShop.Domain.Constants;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var users = await _mediator.Send(new GetUserProfileQuery());
            return Ok(users);
        }
        [HttpPatch("profile")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("userRole")]
        public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("userRole")]
        public async Task<IActionResult> UnassignUserRole(UnAssignUserRoleCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
