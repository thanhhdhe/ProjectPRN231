using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.PaymentService.DTO
{
    public class PaymentCreateDTO
    {
        public int OrderId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }

        [MaxLength(100)]
        public string? Provider { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
