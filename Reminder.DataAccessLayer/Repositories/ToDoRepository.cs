using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.DataAccessLayer.Repositories
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        public ToDoRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<ToDo> GetAssignedToGroup(Group group)
        {
            return ToDoContext.ToDos
                .Where(x => x.Group.Equals(group))
                .ToList();
        }

        public IEnumerable<ToDo> Get(int pageNumber, int pageSize)
        {
            return ToDoContext.ToDos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public ToDoContext ToDoContext
        {
            get
            {
                return Context as ToDoContext;
            }

        }

    }
}
