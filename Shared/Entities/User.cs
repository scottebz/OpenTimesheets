using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTimesheets.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string JobType { get; set; }
        public string DefaultProj { get; set; }
        public string DefaultActivity { get; set; }


    }
}
