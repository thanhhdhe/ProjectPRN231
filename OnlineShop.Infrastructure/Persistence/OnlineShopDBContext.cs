using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Persistence
{
    public class OnlineShopDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sku> Skus { get; set; }
        public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the iPhone product
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "iPhone 12",
                ProductDesc = "Apple iPhone 12 with advanced features",
                ProductStatus = 1,  // in stock
                ProductAttrs = "{\"brand\": \"Apple\", \"model\": \"iPhone 12\"}",
                IsDeleted = false,
                Sort = 1,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            });

            // Seed related SKUs for the iPhone 12 product with different configurations
            modelBuilder.Entity<Sku>().HasData(
                new Sku
                {
                    Id = 1,
                    SkuNo = "IP12-64-BLACK",
                    SkuName = "iPhone 12 64GB Black",
                    SkuDescription = "iPhone 12 with 64GB storage, Black color",
                    SkuType = 0, // assuming this maps to 64GB storage
                    Status = 1,  // available
                    Sort = 1,
                    SkuStock = 50,
                    SkuPrice = 799.99M,
                    ProductId = 1,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                },
                new Sku
                {
                    Id = 2,
                    SkuNo = "IP12-128-WHITE",
                    SkuName = "iPhone 12 128GB White",
                    SkuDescription = "iPhone 12 with 128GB storage, White color",
                    SkuType = 1, // assuming this maps to 128GB storage
                    Status = 1,  // available
                    Sort = 2,
                    SkuStock = 30,
                    SkuPrice = 849.99M,
                    ProductId = 1,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                },
                new Sku
                {
                    Id = 3,
                    SkuNo = "IP12-256-BLUE",
                    SkuName = "iPhone 12 256GB Blue",
                    SkuDescription = "iPhone 12 with 256GB storage, Blue color",
                    SkuType = 2, // assuming this maps to 256GB storage
                    Status = 1,  // available
                    Sort = 3,
                    SkuStock = 20,
                    SkuPrice = 949.99M,
                    ProductId = 1,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                }
            );
        }
    }
}
