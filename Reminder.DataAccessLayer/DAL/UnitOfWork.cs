using System;
using System.Collections.Generic;
using System.Text;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.Repositories;

namespace Reminder.DataAccessLayer.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoContext _context;

        public UnitOfWork(ToDoContext context)
        {
            _context = context;
            ToDos = new ToDoRepository(context);
            Groups = new GroupRepository(context);
            Users = new UserRepository(context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IToDoRepository ToDos { get;  }
        public IGroupRepository Groups { get; }
        public IUserRepository Users { get; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
