using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Viewmodel.SupplierViewModel;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> GetAllSupplier()
        {
            var data = await _unitOfWork.SupplierGenericRepository.GetAllAsync();
            var listSupplier = new List<SupplierVM>();
            foreach (var item in data)
            {
                var itemNew = _mapper.Map<SupplierVM>(item);
                listSupplier.Add(itemNew);
            }
            return new Response(DATN.InfrastructureLayer.Enums.SystemCode.Success, "Get All Supplier Success", listSupplier);
        }
    }
}