using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductIdAsync(productId);
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ReviewDTO reviewDto)
        {
            await _reviewService.AddReviewAsync(reviewDto);
            return CreatedAtAction(nameof(GetByProductId), new { productId = reviewDto.ProductId }, reviewDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
