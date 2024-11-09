using MediatR;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Conversation.Command
{
    public class CreateConversationHandler : IRequestHandler<CreateConversationCommand, int>
    {
        private readonly IConversationRepository _conversationRepository;

        public CreateConversationHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<int> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = new Domain.Entities.Conversation
            {
                CustomerId = request.CustomerId.ToString(),
                StaffId = request.StaffId.ToString(),
                Subject = request.Subject,
                CreatedAt = DateTime.UtcNow
            };

            await _conversationRepository.AddAsync(conversation);
            return conversation.Id;
        }
    }

}
