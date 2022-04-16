using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanMayAnh.Models;
using WebBanMayAnh.ViewModel;

namespace WebBanMayAnh.DataContext
{
    public partial class DATNContext : DbContext
    {
        public DATNContext()
        {

        }
        public DATNContext(DbContextOptions<DATNContext> options) : base(options)
        {

        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attributes> Attributes { get; set; }
        public virtual DbSet<AttributesPrice> AttributesPrices { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<TransactStatus> TransactStatuses { get; set; }
        public virtual DbSet<SaleCode>  SaleCodes { get; set; }
        public virtual DbSet<Payment>   Payments { get; set; }
        public virtual DbSet<Supplier>    Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DESKTOP-2KS3CPM\\PCC;Database=WebMayAnh;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(x => x.AccountID);
                entity.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleID);
            });
            modelBuilder.Entity<Attributes>(entity =>
            {
                entity.HasKey(x => x.AttributeID);
            });
            modelBuilder.Entity<AttributesPrice>(entity =>
            {
                entity.HasKey(x => x.AttributesPriceID);
                entity.HasOne(x => x.Attributes).WithMany(x => x.AttributesPrices).HasForeignKey(x => x.AttributeID);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatID);  
            });
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierID);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(x => x.CustomerID);
                entity.HasOne(x => x.Location).WithMany(x => x.Customers).HasForeignKey(x => x.LocationID);
            });
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationID);       
            });
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentID);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.OrderID);
                entity.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerID);
                entity.HasOne(x => x.Shipper).WithMany(x => x.Orders).HasForeignKey(x => x.ShipperID);
                entity.HasOne(x => x.TransactStatus).WithMany(x => x.Orders).HasForeignKey(x => x.TransactStatusID);
                entity.HasOne(x => x.Payment).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentID);
               // entity.HasOne(x => x.Location).WithMany(x => x.Orders).HasForeignKey(x => x.LocationID).OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(x => x.OrderDetailID);
                entity.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductID);
                entity.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderID);
            });
            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(x => x.PageID);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductID);
                entity.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CatID);
                entity.HasOne(x => x.Supplier).WithMany(x => x.Products).HasForeignKey(x => x.SupplierID);

            });
            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.HasKey(x => x.AdvertisementID);
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(x => x.RoleID);

            });
            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.HasKey(x => x.ShipperID);
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(x => x.PostID);
                //entity.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CatID);
                entity.HasOne(x => x.Account).WithMany(x => x.Posts).HasForeignKey(x => x.AccountID);

            });
            modelBuilder.Entity<TransactStatus>(entity =>
            {
                entity.HasKey(x => x.TransactStatusID);
            });
            modelBuilder.Entity<SaleCode>(entity =>
            {
                entity.HasKey(x => x.SaleCodeID);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public DbSet<WebBanMayAnh.ViewModel.RegisterViewModel> RegisterViewModel { get; set; }
        public DbSet<WebBanMayAnh.ViewModel.LoginViewModel> LoginViewModel { get; set; }
    }
}
