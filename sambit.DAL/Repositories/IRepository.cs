using sambit.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sambit.DAL.Repositories
{
    public interface IRepository<T> : IDisposable where T : EntityBase
    {
        int Save(T entity);

        bool Delete(T entity);
        bool Delete(int id);

        T Find(int id);

        IQueryable<T> Get();
    }
}
