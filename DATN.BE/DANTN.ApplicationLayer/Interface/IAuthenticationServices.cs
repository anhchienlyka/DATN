using DATN.Data.Dtos;
using DATN.Data.Viewmodel.AccountViewModel;
using System.Threading.Tasks;

namespace DANTN.ApplicationLayer.Interface
{
    public interface IAuthenticationServices
    {
        public Task<string> GenerateNewToken(UserDto userDto);
    }
}