﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public interface IRepositoryBase<T>
    {
        Task AddAsync(T t);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync();
        Task DeleteAsync(T t);
    }
}