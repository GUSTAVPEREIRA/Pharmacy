using Microsoft.EntityFrameworkCore;
using Pharmacy.Model.Categories;

namespace Pharmacy.Infra.Data.Mappings.Categories
{
    public class CategoryMapping : IMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(k => k.Id);
            builder.Entity<Category>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Entity<Category>().Property(p => p.SubName).HasMaxLength(100).IsRequired();
        }
    }
}