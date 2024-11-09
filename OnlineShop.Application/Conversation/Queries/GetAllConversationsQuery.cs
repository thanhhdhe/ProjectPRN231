using MediatR;
using OnlineShop.Application.Conversation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Conversation.Queries
{
    public class GetAllConversationsQuery : IRequest<IEnumerable<ConversationDTO>> { }


}
