using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities
{
    public class Conversation
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; } // User với role 'user'

        [Required]
        public int StaffId { get; set; } // User với role 'staff'

        [MaxLength(255)]
        public string Subject { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        // Navigation properties
        public User Customer { get; set; }
        public User Staff { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
