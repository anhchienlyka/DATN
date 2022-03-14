using AutoMapper;
using DATN.Data.Entities;
using DATN.Data.Viewmodel;
using DATN.Data.Viewmodel.Comment;
using DATN.Data.Viewmodel.Product;

namespace DATN.Data.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //category
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Category, CategoryAddVM>().ReverseMap();
            CreateMap<Category, CategoryUpdateVM>().ReverseMap();

            //cooment
            CreateMap<Comment, CommentVM>().ReverseMap();
            CreateMap<Comment, CommentAddVM>().ReverseMap();
            CreateMap<Comment, CommentUpdateVM>().ReverseMap();
            //cooment
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<Product, ProductAddVM>().ReverseMap();
            CreateMap<Product, ProductUpdateVM>().ReverseMap();
        }
    }
}