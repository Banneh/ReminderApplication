using System;
using System.Collections.Generic;
using System.Text;
using Reminder.DataAccessLayer.Repositories;

namespace Reminder.DataAccessLayer.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IToDoRepository ToDos { get; }
        IGroupRepository Groups { get; }
        int Complete();
    }
}
