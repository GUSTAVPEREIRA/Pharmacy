using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Pharmacy.Infra.Data
{
    public static class DependencyInjectable
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var postgreSQL = configuration.GetSection("ConnectionStrings:PostgreSQL").Value;

            if (string.IsNullOrEmpty(postgreSQL.Trim()))
            {
                throw new Exception("Por favor, configure o acesso ao banco de dados!");
            }

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(postgreSQL, b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });

            return services;
        }
    }
}