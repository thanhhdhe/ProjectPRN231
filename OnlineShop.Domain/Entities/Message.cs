using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int ConversationId { get; set; }

        [Required]
        public string SenderId { get; set; } = default!;

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        // Navigation properties
        public Conversation Conversation { get; set; }
        public User Sender { get; set; } = default!;
    }
}
