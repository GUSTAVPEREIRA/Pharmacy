using Microsoft.EntityFrameworkCore;
using Pharmacy.Infra.Data;
using Pharmacy.Infra.Repositories.IRepositories;
using System;

namespace Pharmacy.Infra.Repositories.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public ApplicationContext Context { get; set; }

        public BaseRepository(ApplicationContext context)
        {
            Context = context;
        }

        public virtual bool Delete(T t)
        {
            try
            {
                Context.Remove(t);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual T FindById(int id)
        {
            return Context.Find<T>(id);
        }

        public virtual T Save(T t)
        {
            Context.Add(t);
            Context.SaveChanges();
            return t;
        }

        public virtual T Updated(T t)
        {
            Context.Add(t).State = EntityState.Modified;
            Context.SaveChanges();
            return t;
        }
    }
}