using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Users;
using OnlineShop.Application.Users.Queries;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var users = await _mediator.Send(new GetUserProfileQuery());
            return Ok(users);
        }
    }
}
