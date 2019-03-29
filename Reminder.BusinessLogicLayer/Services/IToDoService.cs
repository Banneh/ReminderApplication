using Reminder.DataAccessLayer.DataModels;
using System.Collections.Generic;

namespace Reminder.BusinessLogicLayer.Services
{
    public interface IToDoService : IBaseService<ToDo>
    {
        IEnumerable<ToDo> GetByGroup(long groupId);
    }
}
