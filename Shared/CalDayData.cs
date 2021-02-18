using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTimesheets.Shared
{
    public class CalDayData
    {
        public DateTime CalDay { get; set; }
        public decimal HrsWorked{ get; set; }
        public decimal HrsAllocated { get; set; }
        public string Username { get; set; }

        public override string ToString()
        {
            string s = this.CalDay.ToShortDateString() + Environment.NewLine;
            s += "  HrsWorked: " + this.HrsWorked.ToString("#.##") +Environment.NewLine;
            s += "  HrsAlloc : " + this.HrsAllocated.ToString("#.##") + Environment.NewLine;
            s += "  Username : " + this.Username + Environment.NewLine;

            return s;
        }
    }
}
