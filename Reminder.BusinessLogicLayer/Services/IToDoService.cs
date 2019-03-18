using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    public interface IToDoService : IBaseService<ToDo>
    {
        IEnumerable<ToDo> GetByGroup(long groupId);
    }
}
