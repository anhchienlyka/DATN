using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.CategoryViewModel;
using DATN.Data.Entities;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Constants;
using DATN.InfrastructureLayer.Enums;
using System;
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

        public async Task<Response> Add(CategoryAddVM category)
        {
            var data = _mapper.Map<Category>(category);
            //data.CreatedOn = DateTime.Now;
            await _unitOfWork.CategoryGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, Messages.ADDSUCCESS, null);
        }

        public async Task<Response> Delete(int Id)
        {
            var data = await _unitOfWork.CategoryGenericRepository.GetAsync(Id);
            if (data == null /*|| data.IsDeleted == true*/)
            {
                return new Response(SystemCode.Error, "Delete Category Fail", null);
            }
           // data.IsDeleted = true;
            _unitOfWork.CategoryGenericRepository.Update(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete Success", data);
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

        public async Task<Response> GetById(int Id)
        {
            var data = await _unitOfWork.CategoryGenericRepository.GetAsync(Id);
            if (data == null /*|| data.IsDeleted == true*/)
            {
                return new Response(SystemCode.Warning, "Can not find Category", null);
            }
            else
            {
                return new Response(SystemCode.Success, "Find Success", data);
            }
        }

        public async Task<Response> Update(CategoryUpdateVM category)
        {
            var data = await _unitOfWork.CategoryGenericRepository.GetAsync(category.Id);
            if (data == null /*|| data.IsDeleted == true*/)
            {
                return new Response(SystemCode.Warning, "Can not find Category", null);
            }
            //if (data.IsDeleted == true)
            //{
            //    return new Response(SystemCode.Warning, "Category is Deleted", null);
            //}
            else
            {
                var categoryData = _mapper.Map<Category>(category);
              // categoryData.UpdatedOn = DateTime.Now;
                _unitOfWork.CategoryGenericRepository.Update(categoryData);
                await _unitOfWork.CommitAsync();
                return new Response(SystemCode.Success, "Update Success", categoryData);
            }
        }
    }
}