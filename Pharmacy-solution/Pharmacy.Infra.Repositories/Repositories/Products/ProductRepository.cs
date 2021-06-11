using Pharmacy.Infra.Data;
using Pharmacy.Infra.Repositories.IRepositories.Products;
using Pharmacy.Model.Products;
using System.Linq;

namespace Pharmacy.Infra.Repositories.Repositories.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public bool VerifyIfExistProductWithCategoryId(int cateogryId)
        {
            var result = Context.TbProducts.Where(w => w.CategoryId == cateogryId).Any();

            return result;
        }

        public IQueryable<Product> GetAll()
        {
            var list = Context.TbProducts;

            return list;
        }
    }
}