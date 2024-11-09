using AutoMapper;
using MediatR;
using OnlineShop.Application.Message.DTO;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Message.Queries
{

    public class GetMessagesByConversationIdHandler : IRequestHandler<GetMessagesByConversationIdQuery, IEnumerable<MessageDTO>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessagesByConversationIdHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDTO>> Handle(GetMessagesByConversationIdQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetMessagesByConversationIdAsync(request.ConversationId);
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }
    }
}
