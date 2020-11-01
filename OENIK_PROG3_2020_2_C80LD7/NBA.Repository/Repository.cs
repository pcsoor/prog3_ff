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

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="ctx">dbcontext.</param>
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
            this.dbSet = this.ctx.Set<T>();
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <inheritdoc/>
        public abstract T GetOne(int id);

        /// <inheritdoc/>
        public void Insert(T obj)
        {
            this.dbSet.Add(obj);
            this.ctx.SaveChanges();
        }
    }
}
