using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Carts = new HashSet<Cart>();
            ConversationCustomers = new HashSet<Conversation>();
            ConversationStaffs = new HashSet<Conversation>();
            Messages = new HashSet<Message>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
        public string? Position { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Conversation> ConversationCustomers { get; set; }
        public virtual ICollection<Conversation> ConversationStaffs { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
