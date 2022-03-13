using AutoMapper;
using DATN.Data.Entities;
using DATN.Data.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //category
            CreateMap<Category, CategoryVM>().ReverseMap();
        }
    }
}
