using OpenTimesheets.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTimesheets.Client.DataRepository
{
    public interface IShiftRepository
    {
        public WorkShift GetWorkShift(string username, DateTime date);
        public WorkWeek GetWorkWeek(string username, DateTime date);
        public List<ProjAlloc> GetProjAlloc(string username, WorkShift workShift);
    }
}
