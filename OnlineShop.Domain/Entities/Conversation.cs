using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Conversation
    {
        public Conversation()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public string? Subject { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User Customer { get; set; } = null!;
        public virtual User Staff { get; set; } = null!;
        public virtual ICollection<Message> Messages { get; set; }
    }
}
