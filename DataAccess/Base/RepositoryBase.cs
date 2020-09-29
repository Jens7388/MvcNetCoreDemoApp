using Microsoft.EntityFrameworkCore;
using MvcNetCore.Models.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected NorthwindContext context;

        public RepositoryBase(NorthwindContext context) 
        {
            Context = context;
        }

        public RepositoryBase()
        {
            context = new NorthwindContext();
        }

        public virtual NorthwindContext Context
        {
            get { return context; }
            set { context = value; }
        }

        public virtual async Task AddAsync(T t)
        {
            context.Set<T>().Add(t);
            await context.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }


        public virtual async Task UpdateAsync()
        {
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T t)
        {
            context.Set<T>().Remove(t);
            await context.SaveChangesAsync();
        }
    }
}