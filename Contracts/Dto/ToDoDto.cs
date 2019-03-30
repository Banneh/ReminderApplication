using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Dto
{
    public class ToDoDto
    {
        public long ToDoId{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
        public GroupDto Group { get; set; }
    }
}
