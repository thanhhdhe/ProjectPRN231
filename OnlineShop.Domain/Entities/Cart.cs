using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = default!;
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalAmount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public User User { get; set; } = default!;
        public ICollection<CartItem> CartItems { get; set; }
    }
}
