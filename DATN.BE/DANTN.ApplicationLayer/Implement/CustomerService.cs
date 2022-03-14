using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Viewmodel.CustomerViewModel;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.CustomerGenericRepository.GetAllAsync();
            var listData = new List<CustomerVM>();
            foreach (var item in data)
            {
                var customerVm = new CustomerVM();
                customerVm = _mapper.Map<CustomerVM>(item);
                listData.Add(customerVm);
            }
            return new Response(SystemCode.Success, "Get All Success", listData);
        }
    }
}