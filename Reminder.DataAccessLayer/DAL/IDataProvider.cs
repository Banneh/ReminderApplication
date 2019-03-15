using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Reminder.DataAccessLayer.DataModels;

namespace Reminder.DataAccessLayer.DAL
{
    public interface IDataProvider
    {
        DbSet<ToDo> ToDos { get; set; }
        DbSet<Group> Groups { get; set; }
    }
}
