using Microsoft.EntityFrameworkCore;
using Pharmacy.Model.Products;

namespace Pharmacy.Infra.Data.Mappings.Products
{
    public class ProductMapping : IMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(k => k.Id);
            builder.Entity<Product>().HasOne(k => k.Category).WithMany(k => k.Products).HasForeignKey(f => f.CategoryId).IsRequired(true);            
            builder.Entity<Product>().Property(p => p.Name).IsRequired(true);
            builder.Entity<Product>().Property(p => p.Prescrition).IsRequired(true).HasDefaultValue(false);
            builder.Entity<Product>().Property(p => p.CreatedAt).IsRequired(true);
            builder.Entity<Product>().Property(p => p.UpdatedAt).IsRequired(true);
            builder.Entity<Product>().Property(p => p.DeletedAt).IsRequired(false);
        }
    }
}
