using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ReceiverName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AddressDetail { get; set; }
        public string? Ward { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
