using DATN.Data.Entities;
using DATN.DataAccessLayer.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> CategoryGenericRepository { get; }
        IGenericRepository<Comment> CommentGenericRepository { get; }
        IGenericRepository<Customer> CustomerGenericRepository { get; }
        IGenericRepository<Order> OrderGenericRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailGenericRepository { get; }
        IGenericRepository<Payment> PaymentGenericRepository { get; }
        IGenericRepository<Picture> PictureGenericRepository { get; }
        IGenericRepository<Product> ProductGenericRepository { get; }
        IGenericRepository<SaleCode> SaleCodeGenericRepository { get; }
        IGenericRepository<Employee> EmployeeGenericRepository { get; }
        IGenericRepository<Supplier> SupplierGenericRepository { get; }
        IGenericRepository<Role> RoleGenericRepository { get; }






    }
}
