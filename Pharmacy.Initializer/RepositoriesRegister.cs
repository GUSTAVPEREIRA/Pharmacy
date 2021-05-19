using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Infra.Repositories.IRepositories.Users;
using Pharmacy.Infra.Repositories.Repositories.Users;

namespace Pharmacy.Initializer
{
    public static class RepositoriesRegister
    {
        public static void AddRepositories(this IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IUserRepository, UserRepository>();
        }
    }
}