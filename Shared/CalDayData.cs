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
        public decimal HrsWorked { get; set; } = 0
            ;
        public decimal HrsAllocated { get; set; } = 0;
        public string Username { get; set; }

        public override string ToString()
        {
            string s = this.CalDay.ToString("ddd dd/MM/yyyy") + Environment.NewLine;
            s += "  HrsWorked: " + this.HrsWorked.ToString("#.##") +Environment.NewLine;
            s += "  HrsAlloc : " + this.HrsAllocated.ToString("#.##") + Environment.NewLine;
            s += "  Username : " + this.Username + Environment.NewLine;

            return s;
        }
    }
}
