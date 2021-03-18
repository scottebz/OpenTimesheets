using OpenTimesheets.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTimesheets.Client.DataRepository
{
    public interface IWorkShiftRepository
    {
        Task CreateWorkShift(WorkShift ws);
    }
}
