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
        IEnumerable<ToDo> GetByGroup(long groupId);
        ToDo Add(ToDo toDo);
        ToDo Update(long id, ToDo toDo);
        void Delete(ToDo toDo);
    }
}
