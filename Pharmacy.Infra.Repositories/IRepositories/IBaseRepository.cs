using Pharmacy.Infra.Data;

namespace Pharmacy.Infra.Repositories.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        public ApplicationContext Context { get; set; }

        public T Save(T t);
        public T FindById(int id);
        public bool Delete(T t);
        public T Updated(T t);
    }
}
