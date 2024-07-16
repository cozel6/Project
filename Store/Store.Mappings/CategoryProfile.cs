using AutoMapper;
using Store.Entities;
using Store.Models;

namespace Store.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();
        }
    }
}
