using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; } = default!;
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending";
        public string ReceiverName { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string AddressDetail { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ward { get; set; }

        [Required]
        [MaxLength(100)]
        public string District { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public User Customer { get; set; } = default!;
        public ICollection<OrderItem> OrderItems { get; set; }
        public PaymentDetail PaymentDetail { get; set; }
    }
}
