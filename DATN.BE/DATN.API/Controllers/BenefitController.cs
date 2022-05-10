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
        public Task<IActionResult> GetBenefit(string option, string startDate, string endDate)
        {
            
            var option1 = new SqlParameter("@option", option);
            var startDate1 = new SqlParameter("@startDate", startDate);
            var endDate1 = new SqlParameter("@endDate", endDate);
            var context = new DATNDBContex();
            string sql = "EXEC dbo.Pr_Get_Benefit @startDate,@endDate,@option";
            var data = this._dATNDBContext.Database.ExecuteSqlInterpolated($"EXEC dbo.Pr_Get_Benefit @startDate = convert(datetime, {startDate}, 105),@endDate = convert(datetime, {endDate}, 105),@option= {option}");
            return null;

        }
    }
}
