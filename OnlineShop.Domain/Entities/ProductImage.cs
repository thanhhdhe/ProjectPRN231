using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Required]
        public int ProductVariantId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        // Navigation property
        public ProductVariant ProductVariant { get; set; }
    }
}
