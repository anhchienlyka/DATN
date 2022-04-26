using DATN.Data.Entities;
using DATN.DataAccessLayer.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.Implementations
{
    public class SaleCodeRepository : GenericRepository<SaleCode>, ISaleCodeRepository
    {
        public SaleCodeRepository(DATNDBContex contex) : base(contex)
        {

        }
        public Task<SaleCode> GetSaleCode(string saleCodeName)
        {
            return _dbContext.SaleCodes.FirstOrDefaultAsync(x => x.CodeName == saleCodeName);
        }
    }
}
