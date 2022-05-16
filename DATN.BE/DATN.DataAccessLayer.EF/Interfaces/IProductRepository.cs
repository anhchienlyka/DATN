using DATN.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProduct();
        public Task<Product> GetProductById(int id);
        public Task<IEnumerable<Product>> GetProductByView();
        public Task<IEnumerable<Product>> GetFeaturedProduct();
        public Task<IEnumerable<Product>> GetRecentProduct();
        public Task<Product> GetIdProductMax();
        public Task<IEnumerable<Product>> GetProductByName(string name);
        public Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId);
    }
}