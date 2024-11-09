using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Domain.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly OnlineShopDBContext _context;

        public MessageRepository(OnlineShopDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(int conversationId)
        {
            return await _context.Messages
                                 .Where(m => m.ConversationId == conversationId)
                                 .ToListAsync();
        }

        public async Task AddAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }
    }

}
