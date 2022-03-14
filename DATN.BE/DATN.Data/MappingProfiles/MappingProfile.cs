using AutoMapper;
using DATN.Data.CategoryViewModel;
using DATN.Data.Entities;
using DATN.Data.Viewmodel.CommentViewModel;
using DATN.Data.Viewmodel.CustomerViewModel;
using DATN.Data.Viewmodel.OrderDetailViewModel;
using DATN.Data.Viewmodel.OrderViewModel;
using DATN.Data.Viewmodel.ProductViewModel;

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
            //product
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<Product, ProductAddVM>().ReverseMap();
            CreateMap<Product, ProductUpdateVM>().ReverseMap();
            //order
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<Order, OrderAddVM>().ReverseMap();

            //orderDetail
            CreateMap<OrderDetail, OrderDetailAddVM>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailVM>().ReverseMap();

            //customer
            CreateMap<Customer, CustomerVM>().ReverseMap();
        }
    }
}