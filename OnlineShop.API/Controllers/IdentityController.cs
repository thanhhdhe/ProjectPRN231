using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Auth.Command.Login;
using OnlineShop.Application.Auth.Command.Register;

namespace OnlineShop.API.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginCommand command)
        //{
        //    var token = await _mediator.Send(command);
        //    return Ok(new { Token = token });
        //}
        [HttpPost("signUp")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new { Token = token });
        }
    }
}
