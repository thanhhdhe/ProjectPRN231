    using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using OnlineShop.Application.Message.Hub;
namespace OnlineShop.API.Hubs
{

    public class ChatHub : Hub, IMessageHub
    {
        public async Task SendMessageToGroup(int conversationId, string message)
        {
            try
            {
                await Clients.Group(conversationId.ToString()).SendAsync("ReceiveMessage", message);
            }
            catch (Exception ex)
            {
                // Log hoặc in ra lỗi
                Console.WriteLine($"Error in SendMessageToGroup: {ex.Message}");
                throw;
            }
        }

        public async Task JoinConversation(int conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
        }

        public async Task LeaveConversation(int conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString());
        }
    }

}
