using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Entities;
using DATN.Data.Viewmodel.Order;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{

    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Add(OrderAddVM order)
        {
            var customer = await _unitOfWork.CustomerGenericRepository.GetAsync(order.CustomerId);
            var employee = await _unitOfWork.EmployeeGenericRepository.GetAsync(order.EmployeeId);
            if (customer == null)
            {
                return new Response(SystemCode.Error, "Customer not exits", null);
            }

            if (employee == null)
            {
                return new Response(SystemCode.Error, "Employee not exits", null);
            }

            var data = _mapper.Map<Order>(order);
            foreach (var item in data.OrderDetails)
            {
                var product = _unitOfWork.ProductGenericRepository.GetAsync(item.ProductId);
                if (product == null) return new Response(SystemCode.Error, "Product is not exits", null);

                item.OrderId = data.Id;
                await _unitOfWork.OrderDetailGenericRepository.AddAsync(item);
            }
            await _unitOfWork.OrderGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add Order Success", data.Id);
        }

        public Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> GetAll()
        {

            var data = await _unitOfWork.OrderDetailGenericRepository.GetAllAsync();
            var dataNew = new List<OrderVM>();
            foreach (var item in data)
            {
                var itemNew = _mapper.Map<OrderVM>(item);            
                dataNew.Add(itemNew);
            }
            return new Response(SystemCode.Error, "Get all success", dataNew);
        }

        public Task<Response> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetRevenueStatistic(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(OrderUpdateVM order)
        {
            throw new NotImplementedException();
        }
    }
}