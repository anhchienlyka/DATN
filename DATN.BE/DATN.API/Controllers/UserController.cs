using DANTN.ApplicationLayer.Interface;
using DATN.Data.Viewmodel.UserViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await _userService.GetAll();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddVM user)
        {
            var response = await _userService.Add(user);
            return Ok(response);
        }
    }
}