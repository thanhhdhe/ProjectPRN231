using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Users.DTO
{
    public class UserProfileDTO
    {
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
