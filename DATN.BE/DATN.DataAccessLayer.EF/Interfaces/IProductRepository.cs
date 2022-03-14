using DATN.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProductByView();
        public Task<IEnumerable<Product>> GetProductByName(string name);
    }
}