﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reminder.DataAccessLayer.DataModels
{
    public class ToDo
    {
        [Key]
        [Required]
        public long ToDoId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDone { get; set; }
        public Group Group { get; set; }
    }
}
