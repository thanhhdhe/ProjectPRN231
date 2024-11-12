using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using OnlineShop.Application.Message.Hub;
namespace OnlineShop.API.Hubs
{

    public class ChatHub : Hub, IMessageHub
    {
        public async Task SendMessageToGroup(string conversationId, string message)
        {
            try
            {
                await Clients.Group(conversationId).SendAsync("ReceiveMessage", new
                {
                    content = message,
                    timestamp = DateTime.UtcNow,
                    senderId = Context.ConnectionId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SendMessageToGroup: {ex.Message}");
                throw;
            }
        }

        public async Task JoinConversation(string conversationId)
        {
            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JoinConversation: {ex.Message}");
                throw;
            }
        }

        public async Task LeaveConversation(string conversationId)
        {
            try
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LeaveConversation: {ex.Message}");
                throw;
            }
        }
    }

}
