using System.Collections.Generic;
using Reminder.DataAccessLayer.DataModels;

namespace Reminder.DataAccessLayer.Repositories
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        IEnumerable<ToDo> GetAssignedToGroup(Group group);
        IEnumerable<ToDo> Get(int pageNumber, int pageSize);
    }
}
