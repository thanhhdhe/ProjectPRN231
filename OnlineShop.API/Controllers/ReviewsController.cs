using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Reviews.Command.CreateReview;
using OnlineShop.Application.Reviews.Command.DeleteReview;
using OnlineShop.Application.Reviews.Command.UpdateReview;
using OnlineShop.Application.Reviews.Queries.GetReviewsByProduct;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
        {
            var reviewId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetReviewById), new { id = reviewId }, null);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetReviewsByProduct(int productId)
        {
            var reviews = await _mediator.Send(new GetReviewsByProductQuery { ProductId = productId });
            return Ok(reviews);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Review ID mismatch");
            }
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _mediator.Send(new DeleteReviewCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _mediator.Send(new GetReviewsByProductQuery { ProductId = id });
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
    }
}
