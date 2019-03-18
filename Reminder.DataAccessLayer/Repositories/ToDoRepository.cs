using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public override IEnumerable<ToDo> GetAll()
        {
            return ToDoContext.ToDos
                .Include(x => x.Group)
                .AsEnumerable();
        }


        public override ToDo Get(long id)
        {
            return ToDoContext.ToDos
                .Where(x => x.ToDoId.Equals(id))
                .Include(x => x.Group)
                .FirstOrDefault();
        }

        public IEnumerable<ToDo> GetAssignedToGroup(long groupId)
        {
            return ToDoContext.ToDos
                .Include(x => x.Group)
                .Where(x => x.Group != null)
                .Where(x => x.Group.GroupId == groupId)
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
