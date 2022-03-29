using AutoMapper;
using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Dtos;
using DATN.Data.Entities;
using DATN.Data.Viewmodel.AccountViewModel;
using DATN.Data.Viewmodel.UserViewModel;
using DATN.DataAccessLayer.EF.Interfaces;
using DATN.DataAccessLayer.EF.UnitOfWorks;
using DATN.InfrastructureLayer.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Implement
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;


        }

        public async Task<Response> Add(UserAddVM user)
        {
            if (await _userRepository.GetUserByUserName(user.UserName) != null)
            {
                return new Response(SystemCode.Error, "UserName is Exist", null);
            }
            var data = _mapper.Map<User>(user);
            data.CustomerRank = RANK.A;
            await _unitOfWork.UserGenericRepository.AddAsync(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Add User Success", data.Id);
        }

        public async Task<Response> CheckUserByUserName(string userName)
        {

            var userInfor = await _userRepository.GetUserByUserName(userName);

            var user = _mapper.Map<UserDto>(userInfor);
            if (userInfor == null)
            {
                return new Response(SystemCode.Error, "User not Exist", null);
            }
            if (userInfor.IsDeleted == true)
            {
                return new Response(SystemCode.Error, "User isDeleted", null);
            }
            return new Response(SystemCode.Success, "Check User Success", user);
        }

        public async Task<Response> Delete(int id)
        {
            var userData = await _unitOfWork.UserGenericRepository.GetAsync(id);
            if (userData == null)
            {
                return new Response(SystemCode.Error, "User not Exits", null);
            }
            if (userData.IsDeleted == true)
            {
                return new Response(SystemCode.Error, "User is Deleted", null);
            }
            userData.IsDeleted = true;
            _unitOfWork.UserGenericRepository.Update(userData);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Delete User Success", userData.Id);
        }

        public async Task<Response> GetAll()
        {
            var data = await _unitOfWork.UserGenericRepository.GetAllAsync();
            var listData = new List<UserVM>();
            foreach (var item in data)
            {
                var userVm = new UserVM();
                userVm = _mapper.Map<UserVM>(item);
                listData.Add(userVm);
            }
            return new Response(SystemCode.Success, "Get All Success", listData);
        }

        public async Task<Response> LoginUser(UserInfor user)
        {
            var userData = await _userRepository.GetUserByUserName(user.UserName);
            if (userData==null)
            {
                return new Response(SystemCode.Error, "User not Exits", null);
            }
            if (userData.IsDeleted == true)
            {
                return new Response(SystemCode.Error, "User is Deleted", null);
            }
            if (userData.UserName==user.UserName&&userData.Password==user.PassWord)
            {
                return new Response(SystemCode.Success, "Login Success", userData);

            }
            return new Response(SystemCode.Error, "Login False", null);
        }

        public async Task<Response> Update(UserUpdateVM user)
        {
            var userData = await _unitOfWork.UserGenericRepository.GetAsync(user.Id);
            if (userData == null)
            {
                return new Response(SystemCode.Error, "User not Exits", null);
            }
            if (userData.IsDeleted == true)
            {
                return new Response(SystemCode.Error, "User is Deleted", null);
            }
            var data = _mapper.Map<User>(user);
            _unitOfWork.UserGenericRepository.Update(data);
            await _unitOfWork.CommitAsync();
            return new Response(SystemCode.Success, "Update User Success", user.Id);
        }
    }
}