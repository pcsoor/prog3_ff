using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBA.Repository
{
    /// <summary>
    /// IRepository osztály.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);

        IQueryable<T> GetAll();

        void Insert(T obj);
    }
}
