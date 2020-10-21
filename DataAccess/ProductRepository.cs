using DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using MvcNetCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductRepository: RepositoryBase<Product>
    {
        public ProductRepository(DbContext context) : base(context) { }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await context.Set<Product>()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Set<Product>()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }
    }
}