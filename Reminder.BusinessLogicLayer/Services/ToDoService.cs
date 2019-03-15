using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    internal class ToDoService : IToDoService
    {
        public IDataProvider DataProvider { get; set; }
        public IQueryable<ToDo> Get()
        {
            throw new NotImplementedException();
        }

        public ToDo GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ToDo> GetByGroup(Group @group)
        {
            throw new NotImplementedException();
        }

        public long Add(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public long Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public void Delete(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
