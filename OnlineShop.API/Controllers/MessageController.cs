using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Message.Command;
using OnlineShop.Application.Message.Queries;

namespace OnlineShop.API.Controllers
{
    [Route("api/conversations/{conversationId}/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages(int conversationId)
        {
            var messages = await _mediator.Send(new GetMessagesByConversationIdQuery(conversationId));
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(int conversationId, [FromBody] SendMessageCommand command)
        {
            command.ConversationId = conversationId;
            await _mediator.Send(command);
            return NoContent();
        }
    }

}
