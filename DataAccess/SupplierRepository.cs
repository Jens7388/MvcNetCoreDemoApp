﻿using DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using MvcNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SupplierRepository: RepositoryBase<Supplier>
    {
        public override async Task<Supplier> GetByIdAsync(int id)
        {
            return await context.Suppliers
                .Include(s => s.Products)
                .SingleOrDefaultAsync(p => p.SupplierId == id);
        }

        public override async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await context.Suppliers.Include(s => s.Products).ToListAsync();
        }
    }
}
