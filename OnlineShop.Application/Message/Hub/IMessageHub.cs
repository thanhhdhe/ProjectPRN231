using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Message.Hub
{
    public interface IMessageHub
    {
        Task SendMessageToGroup(int conversationId, string message);
    }

}
