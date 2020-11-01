using Microsoft.EntityFrameworkCore;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBA.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;
        protected DbSet<T> dbSet;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
            this.dbSet = ctx.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Insert(T obj)
        {
            dbSet.Add(obj);
            ctx.SaveChanges();
        }
    }
}
