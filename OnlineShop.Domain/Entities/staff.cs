using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class staff
    {
        public staff()
        {
            News = new HashSet<News>();
        }

        public int StaffId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? Image { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Status { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
