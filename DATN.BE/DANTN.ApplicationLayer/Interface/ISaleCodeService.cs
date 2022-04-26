using DATN.Data;
using DATN.Data.Viewmodel.SaleCodeViewModel;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Interface
{
    public interface ISaleCodeService
    {
        public Task<Response> GetSaleCode(string saleCodeName);
        public Task<Response> DeleteSaleCode(string saleCodeName);
        public Task<Response> AddSaleCode(SaleCodeAddViewModel saleCode);
        public Task<Response> GetAllSaleCode();

    }
}