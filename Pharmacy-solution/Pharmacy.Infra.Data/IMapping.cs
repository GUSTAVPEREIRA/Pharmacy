using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Infra.Data
{
    public interface IMapping
    {
        public void Mapping(ref ModelBuilder builder);
    }
}