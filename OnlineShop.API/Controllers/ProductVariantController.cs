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

        // GET: api/products/{productId}/variants/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            // Truyền cả productId và id vào query
            var variant = await _mediator.Send(new GetVariantByIdQuery(id));
            return variant is not null ? Ok(variant) : NotFound();
        }

        // POST: api/products/{productId}/variants
        [HttpPost]
        public async Task<IActionResult> Create(int productId, [FromBody] CreateVariantCommand command)
        {
            // Đảm bảo rằng ProductId được gán vào command trước khi gửi tới handler
            command.ProductId = productId;

            // Gửi yêu cầu tạo variant
            var id = await _mediator.Send(command);

            // Trả về HTTP 201 Created với đường dẫn tới resource mới được tạo
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
            // Gửi yêu cầu xóa variant
            await _mediator.Send(new DeleteVariantCommand { Id = id });
            return NoContent();
        }
    }
}
