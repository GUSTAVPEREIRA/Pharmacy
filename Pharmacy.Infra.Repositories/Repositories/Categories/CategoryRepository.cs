using Pharmacy.Infra.Data;
using Pharmacy.Infra.Repositories.IRepositories.Categories;
using Pharmacy.Model.Categories;
using System.Linq;

namespace Pharmacy.Infra.Repositories.Repositories.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }        

        public IQueryable<Category> GetAll()
        {
            var list = Context.TbCategories;

            return list;
        }
    }
}