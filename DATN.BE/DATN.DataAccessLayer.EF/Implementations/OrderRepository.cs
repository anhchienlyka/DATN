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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {

        public OrderRepository(DATNDBContex contex) : base(contex)
        {

        }

        public async Task<Order> GetOrderByOrderId(int id)
        {
            return await _dbContext.Orders.Include(x => x.User).Include(x => x.Payment).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrderByUserId(int userId)
        {
            return await _dbContext.Orders.Include(x => x.User).Include(x => x.Payment).Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
