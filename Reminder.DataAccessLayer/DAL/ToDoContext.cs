using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Reminder.DataAccessLayer.DataModels;

namespace Reminder.DataAccessLayer.DAL
{
    public class ToDoContext : DbContext, IDataProvider
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TaskListDb;Trusted_Connection=True");
        }
    }
}
