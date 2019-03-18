using System;
using System.Collections.Generic;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    public class ToDoService : IToDoService
    {
        public ToDoService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public IEnumerable<ToDo> Get()
        {
            return UnitOfWork.ToDos.GetAll();
        }

        public ToDo GetById(long id)
        {
            ToDo toReturn = UnitOfWork.ToDos
                .Get(id);

            return toReturn;
        }

        public IEnumerable<ToDo> GetByGroup(long groupId)
        {
            IEnumerable<ToDo> toReturn = UnitOfWork.ToDos
                .GetAssignedToGroup(groupId);

            return toReturn;
        }

        public void Add(ToDo toDo)
        {
            toDo.Created = DateTime.UtcNow;
            toDo.IsDone = false;

            UnitOfWork.ToDos
                .Add(toDo);

            UnitOfWork.Complete();
        }

        public void Update(long id, ToDo toDo)
        {
            ToDo toUpdate = GetById(id);

            toUpdate.Description = toDo.Description;
            toUpdate.Group = toDo.Group;
            toUpdate.IsDone = toDo.IsDone;
            toUpdate.DueDate = toDo.DueDate;
            toUpdate.Name = toDo.Name;


            UnitOfWork.ToDos
                .Update(toUpdate);

            UnitOfWork.Complete();
        }

        public void Delete(ToDo toDo)
        {
            UnitOfWork.ToDos.Remove(toDo);
            UnitOfWork.Complete();
        }
    }
}