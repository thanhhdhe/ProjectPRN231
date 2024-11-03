using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }

        // Self-referencing relationship
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; }
    }

}
