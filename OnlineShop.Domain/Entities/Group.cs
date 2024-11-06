using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Group
    {
        public Group()
        {
            Products = new HashSet<Product>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
