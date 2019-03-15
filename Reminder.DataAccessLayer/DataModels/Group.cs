using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reminder.DataAccessLayer.DataModels
{
    public class Group
    {
        public long GroupId { get; set; }
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }
    }
}
