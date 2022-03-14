﻿using DANTN.ApplicationLayer.Interface;
using DATN.Data;
using DATN.Data.Viewmodel.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
