using Microsoft.EntityFrameworkCore;

using MvcNetCore.Models;

using MvcNetCoreDemoApp_DataAccess.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcNetCoreDemoApp_DataAccess
{
    public class ProductRepository: RepositoryBase<Product>
    {
        protected const string supplier = "Supplier";
        protected const string category = "Category";

        public override Product GetBy(int id)
        {
            return context.Products
                .Include(supplier)
                .Include(category)
                .SingleOrDefault(p => p.ProductId == id);
        }

        public override IEnumerable<Product> GetAll()
        {
            return context.Products.Include(supplier).Include(category);
        }
    }
}