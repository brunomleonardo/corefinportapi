﻿using FinPort.Core;
using System.Collections.Generic;
using System.Linq;

namespace FinPort.Data
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        T Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        IQueryable<T> Table { get; }
    }
}