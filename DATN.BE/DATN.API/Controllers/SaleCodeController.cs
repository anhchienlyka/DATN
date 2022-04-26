using DANTN.ApplicationLayer.Interface;
using DATN.Data.Viewmodel.SaleCodeViewModel;
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
    public class SaleCodeController : ControllerBase
    {
        private readonly ISaleCodeService _saleCodeService;
        public SaleCodeController(ISaleCodeService saleCodeService)
        {
            _saleCodeService = saleCodeService;
        }


        [HttpGet]
        public async Task<IActionResult> GetSaleCodeName()
        {
            var response = await _saleCodeService.GetAllSaleCode();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSaleCode(SaleCodeAddViewModel salecode)
        {
            var reponse = await _saleCodeService.AddSaleCode(salecode);
            return Ok(Response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSaleCode(string saleCodeName)
        {
            var reponse = await _saleCodeService.DeleteSaleCode(saleCodeName);
            return Ok(reponse);
        }
    }
}
