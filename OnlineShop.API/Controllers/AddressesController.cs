using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Addresses.Command.CreateAddress;
using OnlineShop.Application.Addresses.Command.DeleteAddress;
using OnlineShop.Application.Addresses.Command.UpdateAddress;
using OnlineShop.Application.Addresses.Queries.GetAllAddressesOfUser;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        { 
            var addressId = await mediator.Send(command);
            return Ok(addressId);
        }
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await mediator.Send(new GetAllAddressesOfUserQuery());
            return Ok(addresses);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAddressCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int id)
        {
            await mediator.Send(new DeleteAddressCommand(id));
            return NoContent();
        }

    }
}
