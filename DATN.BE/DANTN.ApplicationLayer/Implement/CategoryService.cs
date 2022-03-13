using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Entities;
using DATN.Data.Viewmodel;
using DATN.DataAccessLayer.EF.Interfaces;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Constants;
using DATN.InfrastructureLayer.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async  Task<Response> Add(CategoryAddVM category)
        {
            var data =  _mapper.Map<Category>(category);
            await _unitOfWork.CategoryGenericRepository.AddAsync(data);
            return new Response(SystemCode.Success, Messages.ADDSUCCESS, null);
        }

        public Task<Response> Delete()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.CategoryGenericRepository.GetAllAsync();
            var listCategoryVm = new List<CategoryVM>();
            foreach (var item in data)
            {
                var dataVm = _mapper.Map<CategoryVM>(item);
                listCategoryVm.Add(dataVm);
            }
            return new Response(SystemCode.Success, Messages.SUCCESS, listCategoryVm);
        }

        public Task<Response> GeyById()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response> Update(CategoryUpdateVM category)
        {
            throw new System.NotImplementedException();
        }
    }
}