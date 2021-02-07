using System;
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
    }

    public class WorkWeek
    {
        public List<WorkShift> WorkShifts { get; set; } = new List<WorkShift>();

    }
}
