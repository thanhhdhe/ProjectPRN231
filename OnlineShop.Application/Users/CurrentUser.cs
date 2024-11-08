using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Users
{
    public record CurrentUser(string Id, string Email, IEnumerable<string> Roless)
    {
        public bool IsInRole(string role) => Roless.Contains(role);
    }
}
