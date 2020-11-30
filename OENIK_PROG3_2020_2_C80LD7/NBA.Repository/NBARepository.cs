// <copyright file="NBARepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace NBA.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class includes all the common methods that all of the entities can have.
    /// </summary>
    /// <typeparam name="T">T represents the type of the entity.</typeparam>
    public abstract class NBARepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Represents the database.
        /// </summary>
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="NBARepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">dbcontext.</param>
        public NBARepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <inheritdoc/>
        public abstract T GetOne(int id);

        /// <inheritdoc/>
        public void Insert(T attr)
        {
            this.ctx.Set<T>().Add(attr);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Delete on element from the database.
        /// </summary>
        /// <param name="attr">gives an entity to delete.</param>
        public void Remove(T attr)
        {
            this.ctx.Set<T>().Remove(attr);
            this.ctx.SaveChanges();
        }
    }
}
