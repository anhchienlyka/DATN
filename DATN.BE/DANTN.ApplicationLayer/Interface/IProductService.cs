using DATN.Data;
using DATN.Data.Viewmodel.ProductViewModel;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Interface
{
    public interface IProductService
    {
        public Task<Response> GetAll();

        public Task<Response> GetById(int id);

        public Task<Response> GetByName(string name);

        public Task<Response> Add(ProductAddVM product);

        public Task<Response> Update(ProductUpdateVM product);

        public Task<Response> Detele(int id);

        public Task<Response> GetProductByView();
        public Task<Response> GetFeaturedProduct();
        public Task<Response> GetRecentProduct();
    }
}