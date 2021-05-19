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
            CreateMap<User, NewUserDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Username, opt => opt.MapFrom(o => o.Username))
                .ForMember(d => d.Password, opt => opt.MapFrom(o => o.Password));

            CreateMap<NewUserDTO, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Username, opt => opt.MapFrom(o => o.Username))
                .AfterMap((o, d) =>
                {
                    d.SetPassword(o.Password);
                });
        }
    }
}
