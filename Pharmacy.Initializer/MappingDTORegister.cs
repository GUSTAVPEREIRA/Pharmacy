using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.MappingDTO.UsersMapping;

namespace Pharmacy.Initializer
{
    public static class MappingDTORegister
    {
        public static void AddMappingDTO(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile<UserMappingDTO>();
            });

            //Don't remove this line below, because it's used for register the autoMapper
            service.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
