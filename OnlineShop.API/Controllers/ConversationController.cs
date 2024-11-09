using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Conversation.Command;
using OnlineShop.Application.Conversation.Queries;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConversationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var conversations = await _mediator.Send(new GetAllConversationsQuery());
            return Ok(conversations);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConversationCommand command)
        {
            var conversationId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id = conversationId });
        }
    }

}
