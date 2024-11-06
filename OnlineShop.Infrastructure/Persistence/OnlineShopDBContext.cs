using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineShop.Infrastructure.Persistence
{
    public partial class OnlineShopDBContext : DbContext
    {
        public OnlineShopDBContext()
        {
        }

        public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Domain.Entities.Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<AttributeGroup> AttributeGroups { get; set; } = null!;
        public virtual DbSet<AttributeValue> AttributeValues { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryAttribute> CategoryAttributes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<NewsGroup> NewsGroups { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sku> Skus { get; set; } = null!;
        public virtual DbSet<SkuImage> SkuImages { get; set; } = null!;
        public virtual DbSet<Variant> Variants { get; set; } = null!;
        public virtual DbSet<Warranty> Warranties { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=Test;uid=sa;pwd=123456;TrustServerCertificate=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Attribute>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.AttributeGroup)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.AttributeGroupId)
                    .HasConstraintName("FK__Attribute__Attri__5441852A");
            });

            modelBuilder.Entity<AttributeGroup>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<AttributeValue>(entity =>
            {
                entity.Property(e => e.Value).HasMaxLength(100);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributeValues)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK__Attribute__Attri__571DF1D5");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandName).HasMaxLength(255);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<CategoryAttribute>(entity =>
            {
                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.CategoryAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK__CategoryA__Attri__5EBF139D");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryAttributes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__CategoryA__Categ__5DCAEF64");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentContent).HasMaxLength(1000);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Comments__Custom__114A936A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Comments__Produc__10566F31");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactContent).HasMaxLength(1000);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Customer__536C85E4E0973F56")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Customer__A9D105348F8D16B1")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(512);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Image).HasMaxLength(512);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.Username).HasMaxLength(128);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupName).HasMaxLength(128);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.Image).HasMaxLength(512);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__News__CreatedBy__1EA48E88");

                entity.HasOne(d => d.Newsgroup)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.NewsgroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__News__NewsgroupI__1DB06A4F");
            });

            modelBuilder.Entity<NewsGroup>(entity =>
            {
                entity.Property(e => e.NewsgroupName).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.AddressReceiver).HasMaxLength(512);

                entity.Property(e => e.NameReceiver).HasMaxLength(255);

                entity.Property(e => e.Payment).HasMaxLength(50);

                entity.Property(e => e.PhoneReceiver).HasMaxLength(15);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Pending')");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__07C12930");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.ListPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__0B91BA14");

                entity.HasOne(d => d.Sku)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.SkuId)
                    .HasConstraintName("FK__OrderDeta__SkuId__0C85DE4D");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductDesc).HasMaxLength(1000);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.ProductStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.Slug).HasMaxLength(255);

                entity.Property(e => e.Sort).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.ThumbnailUrl).HasMaxLength(512);

                entity.Property(e => e.UpdateTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Products__BrandI__693CA210");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Products__Catego__68487DD7");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Products__GroupI__6A30C649");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductAt__Attri__7D439ABD");

                entity.HasOne(d => d.AttributeValue)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.AttributeValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductAt__Attri__7E37BEF6");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductAt__Produ__7C4F7684");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61602D9AAA46")
                    .IsUnique();

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Sku>(entity =>
            {
                entity.ToTable("SKUs");

                entity.HasIndex(e => e.SkuNo, "UQ__SKUs__AED6232FAD192379")
                    .IsUnique();

                entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PromotionalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SkuDescription).HasMaxLength(500);

                entity.Property(e => e.SkuName).HasMaxLength(255);

                entity.Property(e => e.SkuNo).HasMaxLength(50);

                entity.Property(e => e.Sort).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Skus)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__SKUs__ProductId__797309D9");
            });

            modelBuilder.Entity<SkuImage>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.ImageUrl).HasMaxLength(512);

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Sku)
                    .WithMany(p => p.SkuImages)
                    .HasForeignKey(d => d.SkuId)
                    .HasConstraintName("FK__SkuImages__SkuId__01142BA1");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.Property(e => e.AttributeName).HasMaxLength(50);

                entity.Property(e => e.AttributeValue).HasMaxLength(100);

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.HasOne(d => d.Sku)
                    .WithMany(p => p.Variants)
                    .HasForeignKey(d => d.SkuId)
                    .HasConstraintName("FK__Variants__SkuId__04E4BC85");
            });

            modelBuilder.Entity<Warranty>(entity =>
            {
                entity.Property(e => e.ImageProduct).HasMaxLength(512);

                entity.Property(e => e.ImageProductAdmin).HasMaxLength(512);

                entity.Property(e => e.ProductStatus).HasMaxLength(50);

                entity.Property(e => e.ProductStatusAdmin).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.WarrantyStatus).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Warranties)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Warrantie__Custo__17F790F9");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.Warranties)
                    .HasForeignKey(d => d.OrderDetailId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Warrantie__Order__160F4887");

                entity.HasOne(d => d.Sku)
                    .WithMany(p => p.Warranties)
                    .HasForeignKey(d => d.SkuId)
                    .HasConstraintName("FK__Warrantie__SkuId__17036CC0");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.HasIndex(e => e.Username, "UQ__Staff__536C85E400FE00F4")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Staff__A9D10534ED11855D")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Image).HasMaxLength(512);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.Username).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Staff__RoleId__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
