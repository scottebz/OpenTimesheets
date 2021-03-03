using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTimesheets.Shared.Entities
{
    public class WorkShift
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int UserFk { get; set; }
        public DateTime ShiftDate { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public decimal HrsElapsed { get; set; }
        public decimal HrsBreak { get; set; } 
        public decimal HrsNorm { get; set; }

        public string ToString()
        {
            string s = "";
            s += ShiftDate.ToString("yyyy-MM-dd") + ": ";
            s += ShiftStart.ToString("HH:mm") + " - ";
            s += ShiftEnd.ToString("HH:mm") + Environment.NewLine;
            s += HrsElapsed.ToString() + " - " + HrsBreak.ToString() + " = " + HrsNorm;

            return s;
        }
    }

    public class WorkWeek: IEnumerable<WorkShift>
    {
        public List<WorkShift> WorkShifts { get; set; } = new List<WorkShift>();

        public IEnumerator<WorkShift> GetEnumerator()
        {
            return WorkShifts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
