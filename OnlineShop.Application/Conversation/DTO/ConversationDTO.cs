using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Conversation.DTO
{
    public class ConversationDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
