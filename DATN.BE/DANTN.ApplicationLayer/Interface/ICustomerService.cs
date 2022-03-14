using DATN.Data;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Interface
{
    public interface ICustomerService
    {
        public Task<Response> GetAll();
    }
}