using System;
using System.Collections.Generic;
using System.Text;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    public interface IUserService
    {
        IUnitOfWork UnitOfWork { get; }

        User Authenticate(string username, string password);
        User GetById(long id);
        User Add(User entity, string password);
        void Update(long id, User entity, string password);
        void Delete(long id);
    }
}
