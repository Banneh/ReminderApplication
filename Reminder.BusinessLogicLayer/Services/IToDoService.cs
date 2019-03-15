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
        IDataProvider DataProvider { get; set; }
        IQueryable<ToDo> Get();
        ToDo GetById(long id);
        IQueryable<ToDo> GetByGroup(Group group);
        long Add(ToDo toDo);
        long Update(ToDo toDo);
        void Delete(ToDo toDo);
        void DeleteById(long id);
    }
}
