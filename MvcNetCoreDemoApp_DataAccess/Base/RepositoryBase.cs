using System;
using System.Collections.Generic;
using System.Text;

namespace MvcNetCoreDemoApp_DataAccess.Base
{/*
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected static NorthwindContext context;

        static RepositoryBase()
        {
            context = new NorthwindContext();
        }

        protected RepositoryBase() { }


        public void Add(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual T GetBy(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T t)
        {
            context.SaveChanges();
        }
    }*/
}