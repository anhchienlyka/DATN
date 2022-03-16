using DATN.Data.Entities;
using DATN.DataAccessLayer.EF.Implementations;
using DATN.DataAccessLayer.EF.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DATNDBContex _db;

        protected IGenericRepository<Category> _categoryGenericRepository;
        protected IGenericRepository<Comment> _commentGenericRepository;
        protected IGenericRepository<Order> _orderGenericRepository;
        protected IGenericRepository<OrderDetail> _orderDetailGenericRepository;
        protected IGenericRepository<Payment> __paymentGenericRepository;
        protected IGenericRepository<Picture> _pictureyGenericRepository;
        protected IGenericRepository<Product> _productGenericRepository;
        protected IGenericRepository<SaleCode> _saleCodeGenericRepository;
     
        protected IGenericRepository<Supplier> _supplierGenericRepository;
        protected IGenericRepository<User> _userGenericRepository;
        protected IGenericRepository<Role> _roleGenericRepository;

        public UnitOfWork(DATNDBContex db)
        {
            _db = db;
        }

        public IGenericRepository<Category> CategoryGenericRepository
        {
            get => _categoryGenericRepository ?? new GenericRepository<Category>(_db);
        }

        public IGenericRepository<Comment> CommentGenericRepository
        {
            get => _commentGenericRepository ?? new GenericRepository<Comment>(_db);
        }

        public IGenericRepository<User> UserGenericRepository
        {
            get => _userGenericRepository ?? new GenericRepository<User>(_db);
        }

        public IGenericRepository<Order> OrderGenericRepository
        {
            get => _orderGenericRepository ?? new GenericRepository<Order>(_db);
        }

        public IGenericRepository<OrderDetail> OrderDetailGenericRepository
        {
            get => _orderDetailGenericRepository ?? new GenericRepository<OrderDetail>(_db);
        }

        public IGenericRepository<Payment> PaymentGenericRepository
        {
            get => __paymentGenericRepository ?? new GenericRepository<Payment>(_db);
        }

        public IGenericRepository<Picture> PictureGenericRepository
        {
            get => _pictureyGenericRepository ?? new GenericRepository<Picture>(_db);
        }

        public IGenericRepository<Product> ProductGenericRepository
        {
            get => _productGenericRepository ?? new GenericRepository<Product>(_db);
        }

        public IGenericRepository<SaleCode> SaleCodeGenericRepository
        {
            get => _saleCodeGenericRepository ?? new GenericRepository<SaleCode>(_db);
        }

      

        public IGenericRepository<Supplier> SupplierGenericRepository
        {
            get => _supplierGenericRepository ?? new GenericRepository<Supplier>(_db);
        }

        public IGenericRepository<Role> RoleGenericRepository
        {
            get => _roleGenericRepository ?? new GenericRepository<Role>(_db);
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _db.SaveChangesAsync(new CancellationToken());
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _db.Database.BeginTransactionAsync();
        }
    }
}