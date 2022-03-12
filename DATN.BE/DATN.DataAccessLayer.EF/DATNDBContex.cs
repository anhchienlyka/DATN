using DATN.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF
{
    public class DATNDBContex : DbContext
    {
        public DATNDBContex()
        {

        }

        public DATNDBContex(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleCode> SaleCodes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-KH6IVBO\PCC;Database=DATN;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionsBuilder.LogTo(Console.WriteLine);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(category =>
            {
                category.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Supplier>(supplier =>
            {
                supplier.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Employee>(employee =>
            {
                employee.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Customer>(customer =>
            {
                customer.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Comment>(comment =>
            {
                comment.HasKey(x => x.Id);
                comment.HasOne(k => k.Customer).WithMany(k => k.Comments).HasForeignKey(k => k.CustomerId);
                comment.HasOne(x => x.Product).WithMany(x => x.Comments).HasForeignKey(x => x.ProductId);
                comment.HasOne(x => x.Employee).WithMany(x => x.Comments).HasForeignKey(x => x.EmployeeId);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.HasKey(x => x.Id);
                product.HasOne(x => x.Supplier).WithMany(x => x.Products).HasForeignKey(x => x.SupplierId);
                product.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
                
            });
            modelBuilder.Entity<OrderDetail>(orderDetail =>
            {
                orderDetail.HasKey(x => x.Id);
                orderDetail.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId);
                orderDetail.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            });


            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(x => x.Id);
                order.HasOne(x => x.Employee).WithMany(x => x.Orders).HasForeignKey(x => x.EmployeeId);
                order.HasOne(x => x.Payment).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentId);
            });
            modelBuilder.Entity<Payment>(payment =>
            {
                payment.HasKey(x => x.Id);
            });
            modelBuilder.Entity<SaleCode>(salecode =>
            {
                salecode.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Picture>(img =>
            {
                img.HasKey(x => x.Id);
                img.HasOne(x => x.Product).WithMany(x => x.Pictures).HasForeignKey(x => x.ProductId);
            });
            modelBuilder.Entity<Role>(role =>
            {
                role.HasKey(x => x.Id);
                role.HasOne(x => x.Employee).WithMany(x => x.Roles).HasForeignKey(x => x.EmployeeId);
            });



            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    var tableName = entityType.GetTableName(); if (tableName.StartsWith("AspNet"))
            //    {
            //        entityType.SetTableName(tableName.Substring(6));
            //    }
            //}
        }
    }
}
