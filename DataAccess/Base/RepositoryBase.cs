using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected DbContext context;

        public RepositoryBase(DbContext context) 
        {
            this.context = context;
        }

        public RepositoryBase()
        {
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

        public virtual async Task UpdateAsync(T t)
        {
            context.Set<T>().Update(t);
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T t)
        {
            context.Set<T>().Remove(t);
            await context.SaveChangesAsync();
        }
    }
}