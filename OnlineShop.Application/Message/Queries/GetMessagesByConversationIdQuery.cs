using MediatR;
using OnlineShop.Application.Message.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Message.Queries
{
    public class GetMessagesByConversationIdQuery : IRequest<IEnumerable<MessageDTO>>
    {
        public int ConversationId { get; set; }

        public GetMessagesByConversationIdQuery(int conversationId)
        {
            ConversationId = conversationId;
        }
    }
}
