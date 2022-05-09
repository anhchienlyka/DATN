using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Entities;
using DATN.Data.Viewmodel.OrderViewModel;
using DATN.DataAccessLayer.EF.Interfaces;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IOrderRepository _orderRepository;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IOrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<Response> Add(OrderAddVM order)
        {
            var user = await _unitOfWork.UserGenericRepository.GetAsync(order.UserId);
            if (user == null) return new Response(SystemCode.Error, "User not exits", null);
            var data = _mapper.Map<Order>(order);
            foreach (var item in data.OrderDetails)
            {
                var product = await _unitOfWork.ProductGenericRepository.GetAsync(item.ProductId);
                if (product == null) return new Response(SystemCode.Error, "Product is not exits", null);
                item.OrderId = data.Id;
                product.Inventory -= item.Quantity;
                _unitOfWork.ProductGenericRepository.Update(product);
                await _unitOfWork.OrderDetailGenericRepository.AddAsync(item);
            }
            if (order.FullName == null && order.Phone == null && order.Address == null && order.Email == null)
            {
                data.FullName = user.FullName;
                data.Email = user.Email;
                data.Phone = user.Phone;
                data.Address = user.Address;
            }
            data.OrderNumber = data.OrderDetails.Count();
            data.TransacStatus = DeliveryStatus.PENDING;
            data.PaymentDate = DateTime.Now;
            data.CreateDate = DateTime.Now;
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
            var data = await _unitOfWork.OrderGenericRepository.GetAllAsync();
            var dataNew = new List<OrderVM>();
            foreach (var item in data)
            {
                var itemNew = _mapper.Map<OrderVM>(item);
                dataNew.Add(itemNew);
            }
            return new Response(SystemCode.Error, "Get all success", dataNew);
        }

        public async Task<Response> GetById(int id)
        {
            var data = await _orderRepository.GetOrderByOrderId(id);
            var dataNew = _mapper.Map<OrderVM>(data);
            if (dataNew == null)
            {
                return new Response(SystemCode.Error, "Order is null", null);
            }
            return new Response(SystemCode.Success, "Get Order Success", dataNew);
        }

        public async Task<Response> GetOrderByUserId(int userId)
        {
            var data = await _orderRepository.GetOrderByUserId(userId);
            var dataNew = _mapper.Map<OrderVM>(data);
            if (dataNew == null)
            {
                return new Response(SystemCode.Error, "Order is null", null);
            }
            return new Response(SystemCode.Success, "Get Order Success", dataNew);
        }

        public Task<Response> GetRevenueStatistic(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(OrderUpdateVM order)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateStatusOrder(OrderStatusUpdateVM orderStatus)
        {
            var user = await _unitOfWork.UserGenericRepository.GetAsync(orderStatus.UserId);
            if (user == null)
            {
                return new Response(SystemCode.Error, "Can not find User", null);
            }
            if (user.IsDeleted == true)
            {
                return new Response(SystemCode.Error, "User is Deleted", null);
            }

            return null;
        }
    }
}