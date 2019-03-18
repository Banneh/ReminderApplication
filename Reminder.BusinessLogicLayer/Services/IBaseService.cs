using System;
using System.Collections.Generic;
using System.Text;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    public interface IBaseService<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }
        IEnumerable<TEntity> Get();
        TEntity GetById(long id);
        void Add(TEntity entity);
        void Update(long id, TEntity entity);
        void Delete(TEntity entity);
    }
}
