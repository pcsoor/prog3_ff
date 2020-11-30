// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System.Linq;

    /// <summary>
    /// IRepository osztály.
    /// </summary>
    /// <typeparam name="T">T represents the type of entity.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Returns one entity.
        /// </summary>
        /// <param name="id">the entity' id.</param>
        /// <returns>entity specific value.</returns>
        T GetOne(int id);

        /// <summary>
        /// Returns an IQueryable collection of entities.
        /// </summary>
        /// <returns>Entity specific value.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Inserts data into database.
        /// </summary>
        /// <param name="attr">Entity specific attribute.</param>
        void Insert(T attr);

        /// <summary>
        /// Removes an element.
        /// </summary>
        /// <param name="attr">get one entity to delete.</param>
        void Remove(T attr);
    }
}
