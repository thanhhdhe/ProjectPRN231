using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Products;
using OnlineShop.Application.Products.Command.CreateProduct;
using OnlineShop.Application.Products.DTO;
using OnlineShop.Application.Products.Queries.GetAllProduct;
using OnlineShop.Application.Products.Queries.GetProductById;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQuery query)
        {
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        //get product by id
        public async Task<IActionResult> GetProductById([FromRoute] long id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product is null) {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductCommand command)
        {
           long id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new {id}, null);
        }
    }
}
