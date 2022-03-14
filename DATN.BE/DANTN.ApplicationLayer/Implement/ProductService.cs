using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Entities;
using DATN.Data.Viewmodel.Product;
using DATN.DataAccessLayer.EF.Interfaces;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Enums;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Response> Add(ProductAddVM product)
        {
            var category = await _unitOfWork.CategoryGenericRepository.GetAsync(product.CategoryId);
            if (category == null)
            {
                return new Response(SystemCode.Warning, "Category not exits", null);
            }

            var supplier = await _unitOfWork.SupplierGenericRepository.GetAsync(product.SupplierId);
            if (supplier == null)
            {
                return new Response(SystemCode.Warning, "Supplier not exits", null);
            }
            var data = _mapper.Map<Product>(product);
            await _unitOfWork.ProductGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add Product Success", data.Id);
        }

        public async Task<Response> Detele(int id)
        {
            var data = await _unitOfWork.ProductGenericRepository.GetAsync(id);
            if (data == null)
            {
                return new Response(SystemCode.Error, "Cannot find Product", null);
            }
            data.IsDeleted = true;
            _unitOfWork.ProductGenericRepository.Update(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete is Success", data);
        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.ProductGenericRepository.GetAllAsync();
            return new Response(SystemCode.Success, "Get All Product Success", data);
        }

        public async Task<Response> GetById(int id)
        {
            var data = await _unitOfWork.ProductGenericRepository.GetAsync(id);
            if (data == null)
            {
                return new Response(SystemCode.Warning, "Cannot find Product", data);
            }
            return new Response(SystemCode.Success, "Get Product Success", data);
        }

        public async Task<Response> GetByName(string name)
        {
            var data = await _productRepository.GetProductByName(name);

            if (data == null)
            {
                return new Response(SystemCode.Warning, "Cannot find Product", data);
            }
            return new Response(SystemCode.Success, "Get Product Success", data);
        }

        public async Task<Response> GetProductByView()
        {
            var data = await _productRepository.GetProductByView();

            if (data == null)
            {
                return new Response(SystemCode.Warning, "Cannot find Product", null);
            }
            return new Response(SystemCode.Success, "Get Product Success", data);
        }

        public async Task<Response> Update(ProductUpdateVM product)
        {

            var data = await _unitOfWork.ProductGenericRepository.GetAsync(product.Id);
            if (data == null || data.IsDeleted == true)
            {
                return new Response(SystemCode.Warning, "Cannot find Product", null);
            }
            var category = await _unitOfWork.CategoryGenericRepository.GetAsync(product.CategoryId);
            if (category==null)
            {
                return new Response(SystemCode.Warning, "Category not exits", null);
            }

            var supplier = await _unitOfWork.SupplierGenericRepository.GetAsync(product.SupplierId);
            if (supplier == null)
            {
                return new Response(SystemCode.Warning, "Supplier not exits", null);
            }
            var dataNew = _mapper.Map<Product>(data);
            _unitOfWork.ProductGenericRepository.Update(dataNew);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update Product Success", dataNew);

        }
    }
}