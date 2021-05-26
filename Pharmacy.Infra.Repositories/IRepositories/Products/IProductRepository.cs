using Pharmacy.Model.Products;
using System.Linq;

namespace Pharmacy.Infra.Repositories.IRepositories.Products
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        bool VerifyIfExistProductWithCategoryId(int categoryId);
        public IQueryable<Product> GetAll();
    }
}