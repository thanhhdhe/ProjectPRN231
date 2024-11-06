using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Gmail { get; set; }
        public DateTime? Dob { get; set; }
        public string? Image { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
