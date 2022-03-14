using DATN.Data;
using DATN.Data.Viewmodel.OrderViewModel;
using System;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Interface
{
    public interface IOrderService
    {
        public Task<Response> Add(OrderAddVM order);

        public Task<Response> Delete(int id);

        public Task<Response> Update(OrderUpdateVM order);

        public Task<Response> GetAll();

        public Task<Response> GetById(int id);

        public Task<Response> GetRevenueStatistic(DateTime startDate, DateTime endDate);
    }
}