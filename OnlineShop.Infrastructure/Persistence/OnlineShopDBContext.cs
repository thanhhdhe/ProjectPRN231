using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Infrastructure.Persistence
{
    public partial class OnlineShopDBContext : IdentityDbContext<User>
    {
        public OnlineShopDBContext()
        {
        }

        public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Conversation> Conversations { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductVariant> ProductVariants { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>(enitity =>
            {
                enitity.ToTable("Users");
            });
            modelBuilder.Entity<IdentityRole>(enitity =>
            {
                enitity.ToTable("Roles");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(enitity =>
            {
                enitity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(enitity =>
            {
                enitity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(enitity =>
            {
                enitity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(enitity =>
            {
                enitity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(enitity =>
            {
                enitity.ToTable("UserTokens");
            });
            // Configure Category relationships
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Conversation relationships
            modelBuilder.Entity<Conversation>()
                .HasOne(c => c.Customer)
                .WithMany(u => u.ConversationsAsCustomer)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conversation>()
                .HasOne(c => c.Staff)
                .WithMany(u => u.ConversationsAsStaff)
                .HasForeignKey(c => c.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
