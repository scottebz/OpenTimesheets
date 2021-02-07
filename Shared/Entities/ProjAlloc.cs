using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTimesheets.Shared.Entities
{
    public class ProjAlloc
    {
        public int Id { get; set; }
        public int WorkShiftFk { get; set; }
        public string ProjCode { get; set; }
        public string Activity { get; set; }
        public decimal Hrs { get; set; }
    }
}
