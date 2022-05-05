using DANTN.ApplicationLayer.Interface;
using DATN.Data.Viewmodel.OrderViewModel;
using DATN.InfrastructureLayer.Constants;
using DATN.InfrastructureLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var response = await _orderService.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderAddVM order)
        {
            var response = await _orderService.Add(order);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateStatusOrder(OrderStatusUpdateVM order)
        {
            var response = await _orderService.UpdateStatusOrder(order);
            return Ok(response);
        }
    }
}