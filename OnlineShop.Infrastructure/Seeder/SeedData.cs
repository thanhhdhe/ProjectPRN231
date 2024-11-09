using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Constants;
using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Seeder
{
    public class SeedData(OnlineShopDBContext dbContext) : ISeedData
    {
        public async Task Seed()
        {
           
            if (await dbContext.Database.CanConnectAsync())
            {

                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new (UserRoles.Customer)
                {
                    NormalizedName = UserRoles.Customer.ToUpper()
                },
                new (UserRoles.Sale)
                {
                    NormalizedName = UserRoles.Sale.ToUpper()
                },
                new (UserRoles.Admin)
                {
                    NormalizedName = UserRoles.Admin.ToUpper()
                },
            ];

            return roles;
        }
    }
}
