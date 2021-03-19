using OpenTimesheets.Client.Helpers;
using OpenTimesheets.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTimesheets.Client.DataRepository
{
    public class WorkShiftRepository : IWorkShiftRepository
    {
        private IHttpService httpService;
        private string url = "api/workshift";

        public WorkShiftRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        //returns int of created workshift
        public async Task CreateWorkShift(WorkShift ws)
        {
            var response = await httpService.Post(url, ws);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
