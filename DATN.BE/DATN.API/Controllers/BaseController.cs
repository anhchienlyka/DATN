using DATN.Data.Viewmodel.AccountViewModel;
using DATN.InfrastructureLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        public BaseController()
        {
        }

        public BaseController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public ActivatingUserModel CurrentUser
        {
            get
            {
                if (User == null) return null;
                var userId = User.FindFirst(o => o.Type == ClaimTypes.SerialNumber).Value;
                var userName = User.FindFirst(o => o.Type == ClaimTypes.Name).Value;
                var role = User.FindFirst(o => o.Type == ClaimTypes.Role).Value;

                return new ActivatingUserModel()
                {
                    UserId = int.Parse(userId),
                    UserName = userName,
                    Role = role
                };

            }
        }
    }
}
