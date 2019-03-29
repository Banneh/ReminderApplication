using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Api.Helpers
{
    public class AppSettings
    {
        public string DbConnectionString { get; set; }
        public string Secret { get; set; }
    }
}
