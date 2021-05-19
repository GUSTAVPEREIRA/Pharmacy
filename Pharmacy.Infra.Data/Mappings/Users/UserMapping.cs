using Microsoft.EntityFrameworkCore;
using Pharmacy.Model.Users;

namespace Pharmacy.Infra.Data.Mappings.Users
{
    public class UserMapping : IMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(k => k.Id);
            builder.Entity<User>().HasIndex(k => k.Username).IsUnique(true);
            builder.Entity<User>().Property(p => p.Username).HasMaxLength(30).IsRequired();
            builder.Entity<User>().Property(p => p.Password).HasMaxLength(100).IsRequired();
            builder.Entity<User>().Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}