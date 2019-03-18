using System.Collections.Generic;
using Reminder.DataAccessLayer.DataModels;

namespace Reminder.DataAccessLayer.Repositories
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        IEnumerable<ToDo> GetAssignedToGroup(long groupId);
        IEnumerable<ToDo> Get(int pageNumber, int pageSize);
    }
}
