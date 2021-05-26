using AutoMapper;
using Pharmacy.DTO.Products;
using Pharmacy.Model.Products;

namespace Pharmacy.MappingDTO.ProductsMapping
{
    // Please continue using this default.
    // D = Destination
    // O = Origin

    public class ProductMappingDTO : Profile
    {
        public ProductMappingDTO()
        {
            CreateMap<Product, BaseProductDTO>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(o => o.CategoryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Prescrition, opt => opt.MapFrom(o => o.Prescrition));

            CreateMap<BaseProductDTO, Product>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(o => o.CategoryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Prescrition, opt => opt.MapFrom(o => o.Prescrition));          

            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(o => o.CategoryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Prescrition, opt => opt.MapFrom(o => o.Prescrition))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(o => o.CreatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(o => o.UpdatedAt))
                .ForMember(d => d.DeletedAt, opt => opt.MapFrom(o => o.DeletedAt));

            CreateMap<ProductDTO, Product>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(o => o.CategoryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Prescrition, opt => opt.MapFrom(o => o.Prescrition))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(o => o.CreatedAt))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(o => o.UpdatedAt))
                .ForMember(d => d.DeletedAt, opt => opt.MapFrom(o => o.DeletedAt));
        }
    }
}