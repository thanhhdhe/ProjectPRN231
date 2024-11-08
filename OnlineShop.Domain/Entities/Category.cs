﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
