using DATN.Data;
using DATN.Data.Viewmodel.AccountViewModel;
using DATN.Data.Viewmodel.UserViewModel;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Interface
{
    public interface IUserService
    {
        public Task<Response> GetAll();
        public Task<Response> Add(UserAddVM user);
        public Task<Response> Update(UserUpdateVM user);
        public Task<Response> Delete(int id);
        public Task<Response> LoginUser(UserInfor user);
        public Task<Response> CheckUserByUserName(string userName);

    }
}