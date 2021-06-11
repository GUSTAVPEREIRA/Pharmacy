using Pharmacy.Model.Categories;
using System.Linq;

namespace Pharmacy.Infra.Repositories.IRepositories.Categories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IQueryable<Category> GetAll();
    }
}