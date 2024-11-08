using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.ProductImage.Command;
using OnlineShop.Application.ProductImage.Queries;
using OnlineShop.Application.ProductImage.DTO;

namespace OnlineShop.API.Controllers
{
    [Route("api/variants/{variantId}/images")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductImageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var image = await _mediator.Send(new GetProductImageByIdQuery(id));
            return image != null ? Ok(image) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int variantId, [FromBody] AddImageCommand command)
        {
            command.VariantId = variantId;
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteImageCommand { Id = id});
            return NoContent();
        }
    }
}
