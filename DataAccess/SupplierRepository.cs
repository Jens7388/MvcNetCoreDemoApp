using DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using MvcNetCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SupplierRepository: RepositoryBase<Supplier>
    {
        public SupplierRepository(DbContext context) : base(context) { }

        public override async Task<Supplier> GetByIdAsync(int id)
        {
            return await context.Set<Supplier>()
                .Include(s => s.Products)
                .SingleOrDefaultAsync(p => p.SupplierId == id);
        }

        public override async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await context.Set<Supplier>().Include(s => s.Products).ToListAsync();
        }
    }
}