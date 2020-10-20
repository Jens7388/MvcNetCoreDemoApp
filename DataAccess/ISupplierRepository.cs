using MvcNetCore.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(int id);
    }
}