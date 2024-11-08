using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Brand { get; set; }

        [MaxLength(100)]
        public string ModelNumber { get; set; }

        public string Description { get; set; }

        public string Specifications { get; set; }

        [MaxLength(100)]
        public string Warranty { get; set; }

        [MaxLength(255)]
        public string CoverImage { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        // Navigation properties
        public Category Category { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
