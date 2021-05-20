using AutoMapper;
using Pharmacy.DTO.Categories;
using Pharmacy.Model.Categories;

namespace Pharmacy.MappingDTO.CategoriesMapping
{
    public class CategoryMappingDTO : Profile
    {
        public CategoryMappingDTO()
        {
            CreateMap<NewCategoryDTO, Category>()
                .ForMember(d => d.Name, opt => opt.MapFrom((o) => o.Name))
                .ForMember(d => d.SubName, opt => opt.MapFrom((o) => o.Subname));

            CreateMap<Category, CategoryDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom((o) => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom((o) => o.Name))
                .ForMember(d => d.SubName, opt => opt.MapFrom((o) => o.SubName));

            CreateMap<CategoryDTO, Category>()
                .ForMember(d => d.Id, opt => opt.MapFrom((o) => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom((o) => o.Name))
                .ForMember(d => d.SubName, opt => opt.MapFrom((o) => o.SubName));
        }
    }
}