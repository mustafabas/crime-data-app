﻿using CrimeData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimeData.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(ISpecification<T> spec);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(ISpecification<T> spec);
        

    }
}
