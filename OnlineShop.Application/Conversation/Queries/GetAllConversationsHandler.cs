using AutoMapper;
using MediatR;
using OnlineShop.Application.Conversation.DTO;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Conversation.Queries
{
    public class GetAllConversationsHandler : IRequestHandler<GetAllConversationsQuery, IEnumerable<ConversationDTO>>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMapper _mapper;

        public GetAllConversationsHandler(IConversationRepository conversationRepository, IMapper mapper)
        {
            _conversationRepository = conversationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConversationDTO>> Handle(GetAllConversationsQuery request, CancellationToken cancellationToken)
        {
            var conversations = await _conversationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConversationDTO>>(conversations);
        }
    }
}
