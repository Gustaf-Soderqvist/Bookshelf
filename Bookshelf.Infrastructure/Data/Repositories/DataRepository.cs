﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bookshelf.Core.Interfaces.Gateways.Repositories;

namespace Bookshelf.Infrastructure.Data.Repositories
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public DataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
