using Microsoft.Extensions.DependencyInjection;

namespace Pharmacy.Initializer
{
    public static class RepositoriesRegister
    {
        public static void AddRepositories(this IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<Infra.Repositories.IRepositories.Users.IUserRepository, Infra.Repositories.Repositories.Users.UserRepository>();
            serviceColletion.AddScoped<Infra.Repositories.IRepositories.Categories.ICategoryRepository, Infra.Repositories.Repositories.Categories.CategoryRepository>();
        }
    }
}