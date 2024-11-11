using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineShop.Application.ProductVariant.Command;
using OnlineShop.Application.ProductVariant.DTO;
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

        // GET: api/products/{productId}/variants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVariantDTO>>> GetVariantsByProductId(int productId)
        {
            var query = new GetAllVariantsByProductIdQuery(productId);
            var variants = await _mediator.Send(query);

            if (variants == null)
            {
                return NotFound();
            }

            return Ok(variants);
        }

        // GET: api/products/{productId}/variants/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            var variant = await _mediator.Send(new GetVariantByIdQuery(id));
            return variant is not null ? Ok(variant) : NotFound();
        }

        // POST: api/products/{productId}/variants
        [HttpPost]
        public async Task<IActionResult> Create(int productId, [FromBody] CreateVariantCommand command)
        {
            command.ProductId = productId;
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { productId = command.ProductId, id }, null);
        }

        // PUT: api/products/{productId}/variants/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int productId, int id, [FromBody] UpdateVariantCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/products/{productId}/variants/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int productId, int id)
        {
            await _mediator.Send(new DeleteVariantCommand { Id = id });
            return NoContent();
        }
    }
}
