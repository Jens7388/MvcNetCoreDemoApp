using System;
using System.Collections.Generic;

namespace MvcNetCoreDemoApp_DataAccess
{
    public interface IRepositoryBase<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetBy(int id);
        void Update(TEntity t);
        void Add(TEntity t);
        void Delete(TEntity t);
    }
}