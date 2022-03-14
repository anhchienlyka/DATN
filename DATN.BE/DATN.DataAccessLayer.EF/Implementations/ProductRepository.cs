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
    }
}
