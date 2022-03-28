
using DANTN.ApplicationLayer.Interface;
using DATN.Data.Dtos;
using DATN.Data.Viewmodel.AccountViewModel;
using DATN.InfrastructureLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationServices _authentication;
        private readonly IUserService _userService;

        public AccountController(IAuthenticationServices authentication, IUserService userService)
        {
            _authentication = authentication;
            _userService = userService;

        }

        [HttpPost]
        public async Task<IActionResult> LoginAsyn(UserInfor userInfor)
        {
            var responseUser = await _userService.CheckUserByUserName(userInfor.UserName);
            if (responseUser.Code != SystemCode.Success)
            {
                return Ok(responseUser);
            }
            var respone = await _authentication.GenerateNewToken((UserDto)responseUser.Data);
            return Ok(respone);
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserInfor user)
        {
            var responseUser = await _userService.LoginUser(user);
            return Ok(responseUser);
        }

    }
}
