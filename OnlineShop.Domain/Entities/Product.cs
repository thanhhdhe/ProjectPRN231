using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductVariants = new HashSet<ProductVariant>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Brand { get; set; }
        public string? ModelNumber { get; set; }
        public string? Description { get; set; }
        public string? Specifications { get; set; }
        public string? Warranty { get; set; }
        public string? CoverImage { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
