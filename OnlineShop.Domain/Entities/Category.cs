using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            CategoryAttributes = new HashSet<CategoryAttribute>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
