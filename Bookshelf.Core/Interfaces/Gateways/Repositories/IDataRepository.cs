﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Core.Interfaces.Gateways.Repositories
{
    public interface IDataRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> SaveAsync(T entity);
    }
}
