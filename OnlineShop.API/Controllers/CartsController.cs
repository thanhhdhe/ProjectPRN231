using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Carts.Command.AddToCart;
using OnlineShop.Application.Carts.Command.DeleteCartItem;
using OnlineShop.Application.Carts.Queries.GetCartItems;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromCart([FromRoute] int id)
        {
            await mediator.Send(new DeleteCartItemCommand(id));
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            var cartItems = await mediator.Send(new GetCartItemsQuery());
            return Ok(cartItems);
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCartItem(int id, UpdateCartItemCommand command)
        //{
        //    command.Id = id;
        //    await mediator.Send(command);
        //    return NoContent();
        //}
    }
}
