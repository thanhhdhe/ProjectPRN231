using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Role
    {
        public Role()
        {
            staff = new HashSet<staff>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<staff> staff { get; set; }
    }
}
