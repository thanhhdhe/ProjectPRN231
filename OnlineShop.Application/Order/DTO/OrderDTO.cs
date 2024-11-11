using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
