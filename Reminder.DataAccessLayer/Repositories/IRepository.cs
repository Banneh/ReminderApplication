﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Reminder.DataAccessLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

    }
}
