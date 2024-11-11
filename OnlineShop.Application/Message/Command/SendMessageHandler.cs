using MediatR;
using Microsoft.AspNetCore.SignalR;
using OnlineShop.Application.Message.Hub;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Message.Command
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand, Unit>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageHub _messageHub;  

        public SendMessageHandler(IMessageRepository messageRepository, IMessageHub messageHub)
        {
            _messageRepository = messageRepository;
            _messageHub = messageHub;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Domain.Entities.Message
            {
                ConversationId = request.ConversationId,
                SenderId = request.SenderId.ToString(),
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            await _messageRepository.AddAsync(message);

            // Send message to the conversation group using the interface
            await _messageHub.SendMessageToGroup(request.ConversationId, request.Content);

            return Unit.Value;
        }
    }
}
