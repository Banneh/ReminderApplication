using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    public class ToDoService : IToDoService
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public ToDoService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<ToDo> Get()
        {
            return UnitOfWork.ToDos.GetAll();
        }

        public ToDo GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetByGroup(Group @group)
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
