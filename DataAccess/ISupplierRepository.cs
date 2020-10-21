using MvcNetCore.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISupplierRepository
    {
        Task AddAsync(Supplier supplier);
        Task<Supplier> GetByIdAsync(int id);
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(Supplier supplier);
    }
}