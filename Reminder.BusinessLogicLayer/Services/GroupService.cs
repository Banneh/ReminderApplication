using System;
using System.Collections.Generic;
using System.Text;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    public class GroupService : IGroupService
    {
        public IUnitOfWork UnitOfWork { get; }

        public GroupService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<Group> Get()
        {
            IEnumerable<Group> groups = UnitOfWork.Groups
                .GetAll();

            return groups;
        }

        public Group GetById(long id)
        {
            Group groupToReturn = UnitOfWork.Groups
                .Get(id);

            return groupToReturn;
        }

        public void Add(Group entity)
        {
            UnitOfWork.Groups
                .Add(entity);

            UnitOfWork.Complete();
        }

        public void Update(long id, Group entity)
        {
            Group toUpdate = UnitOfWork.Groups
                .Get(id);

            toUpdate.Description = entity.Description;
            toUpdate.Name = entity.Name;

            UnitOfWork.Groups.Update(toUpdate);

            UnitOfWork.Complete();
           }

        public void Delete(Group entity)
        {
            UnitOfWork.Groups
                .Remove(entity);

            UnitOfWork.Complete();
        }
    }
}
