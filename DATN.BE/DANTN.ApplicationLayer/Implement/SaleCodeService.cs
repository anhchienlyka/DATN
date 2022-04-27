using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Entities;
using DATN.Data.Viewmodel.SaleCodeViewModel;
using DATN.DataAccessLayer.EF.Interfaces;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Enums;
using System;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class SaleCodeService : ISaleCodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleCodeRepository _saleCodeRepository;
        private readonly IMapper _mapper;

        public SaleCodeService(IUnitOfWork unitOfWork, IMapper mapper, ISaleCodeRepository saleCodeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _saleCodeRepository = saleCodeRepository;
        }

        public async Task<Response> AddSaleCode(SaleCodeAddViewModel saleCode)
        {
            if (saleCode.EndDateCode<saleCode.StartDateCode)
            {
                return new Response(SystemCode.Error, "EndDate cant not less StartDate", null);
            }
            var saleCodeNew = _mapper.Map<SaleCode>(saleCode);
            await _unitOfWork.SaleCodeGenericRepository.AddAsync(saleCodeNew);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add SaleCode Success", saleCodeNew.Id);
        }

        public async Task<Response> DeleteSaleCode(string saleCodeName)
        {
            var saleCode = await _saleCodeRepository.GetSaleCode(saleCodeName);
            if (saleCode == null) { return new Response(SystemCode.Error, "Salecode is null", null); }
            if (saleCode.IsDelete == false)
            {
                return new Response(SystemCode.Warning, "Sale code can't delete", null);
            }
            _unitOfWork.SaleCodeGenericRepository.Delete(saleCode);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete is Success ", saleCode.Id);
        }

        public async Task<Response> GetAllSaleCode()
        {
            var data = await _unitOfWork.SaleCodeGenericRepository.GetAllAsync();
            return new Response(SystemCode.Success, "Get all success", data);
        }

        public async Task<Response> GetSaleCode(string saleCodeName)
        {
            var data = await _saleCodeRepository.GetSaleCode(saleCodeName);
            if (data == null)
            {
                return new Response(SystemCode.Error, "Get data is null", null);
            }
            var dateNow = DateTime.Now;
            if (data.StartDateCode >= dateNow || data.EndDateCode <= dateNow)
            {
                return new Response(SystemCode.Error, "Ma Khuyen Mai khong ton tai, hoac da bi xoa", null);
            }
            return new Response(SystemCode.Success, "Get data is success", data);
        }
    }
}