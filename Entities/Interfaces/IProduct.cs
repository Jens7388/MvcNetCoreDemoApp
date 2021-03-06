﻿using System.Collections.Generic;

namespace MvcNetCore.Models.Interfaces
{
    public interface IProduct
    {
        Category Category { get; set; }
        int? CategoryId { get; set; }
        bool Discontinued { get; set; }
        ICollection<OrderDetails> OrderDetails { get; set; }
        int ProductId { get; set; }
        string ProductName { get; set; }
        string QuantityPerUnit { get; set; }
        short? ReorderLevel { get; set; }
        Supplier Supplier { get; set; }
        int? SupplierId { get; set; }
        decimal? UnitPrice { get; set; }
        short? UnitsInStock { get; set; }
        short? UnitsOnOrder { get; set; }
    }
}