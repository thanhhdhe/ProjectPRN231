using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
            Warranties = new HashSet<Warranty>();
        }

        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? Image { get; set; }
        public bool? Gender { get; set; }
        public string? Address { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Status { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Warranty> Warranties { get; set; }
    }
}
