using DATN.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.SeedData
{
    public class SeeDatas
    {
        private readonly DATNDBContex _contex;
        public SeeDatas(DATNDBContex contex)
        {
            _contex = contex;
        }
        public void Seed()
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){ CategoryName = "Máy Ảnh",Active=true},
                new Category(){CategoryName = "Máy Quay",Active=true},
                new Category(){CategoryName = "Ống Kính",Active=false},
                new Category(){CategoryName = "Âm Thanh",Active=true},
                new Category(){CategoryName = "Phụ Kiện",Active=true},
                new Category(){CategoryName = "Đồng hồ",Active=false},
                new Category(){CategoryName = "Đồ Công Nghệ Khác",Active=true},
            };
            _contex.Categories.AddRange(categories);
            _contex.SaveChanges();
        }
    }
}
