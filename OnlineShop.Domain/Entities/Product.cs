using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            ProductAttributes = new HashSet<ProductAttribute>();
            Skus = new HashSet<Sku>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? GroupId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductDesc { get; set; }
        public byte? ProductStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Sort { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Slug { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? Status { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Group? Group { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<Sku> Skus { get; set; }
    }
}
