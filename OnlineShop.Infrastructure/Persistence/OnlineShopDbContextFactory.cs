using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Persistence
{
    public class OnlineShopDbContextFactory : IDesignTimeDbContextFactory<OnlineShopDbContext>
    {
        public OnlineShopDbContext CreateDbContext(string[] args = null)
        {
            // Tải cấu hình từ file appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Lấy connection string
            var optionsBuilder = new DbContextOptionsBuilder<OnlineShopDbContext>();
            var connectionString = configuration.GetConnectionString("MyDatabase");
            optionsBuilder.UseSqlServer(connectionString);

            return new OnlineShopDbContext(optionsBuilder.Options);
        }
    }
}
