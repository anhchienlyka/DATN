using DATN.Data;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Interface
{
    public interface ISupplierService
    {
        public Task<Response> GetAllSupplier();
    }
}