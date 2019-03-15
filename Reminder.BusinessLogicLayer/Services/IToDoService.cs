using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    public interface IToDoService
    {
        IUnitOfWork UnitOfWork { get; set; }
        IEnumerable<ToDo> Get();
        ToDo GetById(long id);
        IEnumerable<ToDo> GetByGroup(Group group);
        long Add(ToDo toDo);
        long Update(ToDo toDo);
        void Delete(ToDo toDo);
        void DeleteById(long id);
    }
}
