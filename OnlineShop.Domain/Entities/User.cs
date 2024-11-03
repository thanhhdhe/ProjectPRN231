using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }

        // Relationships
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
