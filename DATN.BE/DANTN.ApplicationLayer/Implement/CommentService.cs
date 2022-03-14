using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Entities;
using DATN.Data.Viewmodel.CommentViewModel;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Enums;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Add(CommentAddVM comment)
        {
            var checkCustomer = await _unitOfWork.CustomerGenericRepository.GetAsync(comment.CustomerId);
            var checkEmployee = await _unitOfWork.EmployeeGenericRepository.GetAsync(comment.EmployeeId);
            var checkProduct = await _unitOfWork.ProductGenericRepository.GetAsync(comment.ProductId);
            if (checkCustomer == null && checkEmployee == null && checkProduct == null)
            {
                return new Response(SystemCode.Error, "Add comment Fail", null);
            }
            if (checkCustomer != null && checkEmployee != null)
            {
                return new Response(SystemCode.Error, "Add comment Fail", null);
            }
            var data = _mapper.Map<Comment>(comment);
            await _unitOfWork.CommentGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add Comment Success", data);
        }

        public async Task<Response> Delete(int Id)
        {
            var data = await _unitOfWork.CommentGenericRepository.GetAsync(Id);
            if (data == null)
            {
                return new Response(SystemCode.Error, "Cannot find Comment", null);
            }
            _unitOfWork.CommentGenericRepository.Delete(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete Comment Success", data);
        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.CommentGenericRepository.GetAllAsync();
            return new Response(SystemCode.Success, "Get all Comment Success", data);
        }

        public async Task<Response> Update(CommentUpdateVM comment)
        {
            var data = await _unitOfWork.CommentGenericRepository.GetAsync(comment.Id);
            if (data == null)
            {
                return new Response(SystemCode.Error, "Cannot find Comment", null);
            }
            var dateNew = _mapper.Map<Comment>(comment);
            _unitOfWork.CommentGenericRepository.Update(dateNew);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update Comment Success", data);
        }
    }
}