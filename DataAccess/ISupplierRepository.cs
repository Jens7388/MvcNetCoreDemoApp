using MvcNetCore.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISupplierRepository
    {
        Task AddAsync(Supplier t);
        Task<Supplier> GetByIdAsync(int id);
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task UpdateAsync(Supplier t);
        Task DeleteAsync(Supplier t);
    }
}