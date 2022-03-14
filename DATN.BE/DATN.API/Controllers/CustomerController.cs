using DANTN.ApplicationLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var response = await _customerService.GetAll();
            return Ok(response);
        }
    }
}