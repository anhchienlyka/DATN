using DATN.Data.Viewmodel.BenefitViewModel;
using DATN.DataAccessLayer.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BenefitController : ControllerBase
    {
        private  DATNDBContex _dATNDBContext;
        public BenefitController(  DATNDBContex dATNDBContex)
        {
            this._dATNDBContext = dATNDBContex;
        }
        [HttpGet]
        public async Task<IActionResult> GetBenefit(string option, string startDate, string endDate)
        {

           // var userType = await _dATNDBContext.Database.ExecuteSqlRawAsync("exec Pr_Get_Benefit @startDate,@endDate,@option", startDate, endDate, option).;
            
            return null;

        }
    }
}
