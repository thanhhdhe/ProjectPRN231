using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineShop.Infrastructure.Persistence
{
    public class OnlineShopDbContext : IdentityDbContext<User>
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options) { }

        // Định nghĩa các DbSet cho từng thực thể, ngoại trừ User vì Identity sẽ tự quản lý nó
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Shipping> Shipping { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gọi OnModelCreating của IdentityDbContext để Identity tự cấu hình các bảng của nó
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2); 

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)"); 

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId);

            modelBuilder.Entity<Shipping>()
                .HasOne(s => s.Order)
                .WithOne(o => o.Shipping)
                .HasForeignKey<Shipping>(s => s.OrderId);
        }
    }
}
