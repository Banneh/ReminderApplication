using System;
using System.Collections.Generic;
using System.Text;
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
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IToDoRepository ToDos { get; private set; }
        public IGroupRepository Groups { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
