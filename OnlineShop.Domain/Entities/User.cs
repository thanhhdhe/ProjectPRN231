using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Avatar { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        [MaxLength(100)]
        public string Position { get; set; } // Chỉ áp dụng cho nhân viên

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        // Navigation properties
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Conversation> ConversationsAsCustomer { get; set; }
        public ICollection<Conversation> ConversationsAsStaff { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
