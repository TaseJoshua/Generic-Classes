

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaseFood.StorageApp.Entities;

namespace TaseFood.StorageApp.Repositories
{
 

  
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        //private readonly List<T> _items = new();
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item=> item.Id).ToList();
        }

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public event EventHandler<T>? ItemAdded;

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this,item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }
    }
}