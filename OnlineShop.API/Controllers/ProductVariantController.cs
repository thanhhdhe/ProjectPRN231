using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.ProductVariant.Command;
using OnlineShop.Application.ProductVariant.Queries;
namespace OnlineShop.API.Controllers
{
    [Route("api/products/{productId}/variants")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductVariantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var variant = await _mediator.Send(new GetVariantByIdQuery(id));
            return variant is not null ? Ok(variant) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int productId, [FromBody] CreateVariantCommand command)
        {
            command.ProductId = productId;
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateVariantCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteVariantCommand { Id = id});
            return NoContent();
        }
    }

}
