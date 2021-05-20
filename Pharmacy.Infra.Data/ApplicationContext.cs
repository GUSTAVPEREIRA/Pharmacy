using Microsoft.EntityFrameworkCore;
using Pharmacy.Infra.Data.Mappings.Categories;
using Pharmacy.Infra.Data.Mappings.Users;
using Pharmacy.Model.Categories;
using Pharmacy.Model.Users;

namespace Pharmacy.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        //Code example please use this logic
        public DbSet<User> TbUsers { get; set; }
        public DbSet<Category> TbCategories { get; set; }

        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserMapping().Mapping(ref builder);
            new CategoryMapping().Mapping(ref builder);

            base.OnModelCreating(builder);
        }
    }
}