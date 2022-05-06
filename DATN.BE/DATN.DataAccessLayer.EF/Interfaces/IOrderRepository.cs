using DATN.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> GetOrderByOrderId(int id);

        public Task<IEnumerable<Order>> GetOrderByUserId(int userId);
    }
}