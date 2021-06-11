using AutoMapper;
using Pharmacy.DTO.Users;
using Pharmacy.Model.Users;

namespace Pharmacy.MappingDTO.UsersMapping
{
    // Please continue using this default.
    // D = Destination
    // O = Origin

    public class UserMappingDTO : Profile
    {
        public UserMappingDTO()
        {
            CreateMap<User, BaseUserDTO>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Username, opt => opt.MapFrom(o => o.Username))
                .ForMember(d => d.Password, opt => opt.MapFrom(o => o.Password))
                .AfterMap((o, d) => 
                {
                    d.Password = "";
                });

            CreateMap<BaseUserDTO, User>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Username, opt => opt.MapFrom(o => o.Username))
                .AfterMap((o, d) =>
                {
                    d.SetPassword(o.Password);
                });

            CreateMap<User, UserDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Username, opt => opt.MapFrom(o => o.Username))
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(o => o.UpdatedAt))
                .ForMember(d => d.DeleteAt, opt => opt.MapFrom(o => o.DeletedAt))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(o => o.CreatedAt))
                .ForMember(d => d.Password, opt => opt.Ignore())
                .AfterMap((o, d) =>
                {
                    d.Password = "";
                });            
        }
    }
}