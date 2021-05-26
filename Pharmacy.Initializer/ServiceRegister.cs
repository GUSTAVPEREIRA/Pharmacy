using Microsoft.Extensions.DependencyInjection;

namespace Pharmacy.Initializer
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<Services.IServices.Users.IUserService, Services.Services.Users.UserService>();
            services.AddScoped<Services.IServices.Tokens.ITokenService, Services.Services.Tokens.TokenService>();
            services.AddScoped<Services.IServices.Categories.ICategoryService, Services.Services.Categories.CategoryService>();
            services.AddScoped<Services.IServices.Products.IProductService, Services.Services.Products.ProductService>();
        }
    }
}