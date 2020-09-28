using MvcNetCoreDemoApp_DataAccess.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace MvcNetCoreDemoApp_DataAccess
{/*
    public class SupplierRepository: RepositoryBase<Supplier>
    {
        protected const string products = "Products";
        public override Supplier GetBy(int id)
        {
            return context.Suppliers
                .Include(products)
                .SingleOrDefault(p => p.SupplierId == id);
        }

        public override IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.Include(products);
        }
    }*/
}