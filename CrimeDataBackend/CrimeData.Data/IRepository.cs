using CrimeData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimeData.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T? GetById(int id);
        IEnumerable<T> ListAll();
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
