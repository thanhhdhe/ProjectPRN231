using MediatR;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Conversation.Command
{
    public class CreateConversationCommand : IRequest<int>
    {
        public string CustomerId { get; set; }
        public string StaffId { get; set; }
        public string Subject { get; set; }
    }

    
}
