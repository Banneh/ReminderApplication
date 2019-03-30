using Reminder.DataAccessLayer.DAL;
using System.Collections.Generic;

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
