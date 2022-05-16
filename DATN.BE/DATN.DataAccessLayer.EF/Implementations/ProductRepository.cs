using DATN.Data.Entities;
using DATN.DataAccessLayer.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DATNDBContex contex) : base(contex)
        {

        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _dbContext.Products.AsNoTracking().OrderByDescending(x=>x.Id).Include(x=>x.Supplier).Include(x=>x.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetFeaturedProduct()
        {
            var listProductByVew = await _dbContext.Products.OrderByDescending(x => x.Sale).Take(4).ToListAsync();
            return listProductByVew;
        }

        public async Task<Product> GetIdProductMax()
        {
            return await _dbContext.Products.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId)
        {
            return await _dbContext.Products.Where(x => x.CategoryId == categoryId).Take(4).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.AsNoTracking().Include(x => x.Supplier).Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var listProductByVew = await _dbContext.Products.Where(x => x.Name.Contains(name)).ToListAsync();
            return listProductByVew;
        }

        public async Task<IEnumerable<Product>> GetProductByView()
        {
            var listProductByVew = await _dbContext.Products.OrderByDescending(x => x.ViewProduct).Take(5).ToListAsync();
            return listProductByVew;
        }

        public async Task<IEnumerable<Product>> GetRecentProduct()
        {
            var listProductByVew = await _dbContext.Products.OrderByDescending(x => x.Id).Take(4).ToListAsync();
            return listProductByVew;
        }
    }
}
