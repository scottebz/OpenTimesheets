using OpenTimesheets.Client.Helpers;
using OpenTimesheets.Shared;
using OpenTimesheets.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateTimeExtensions;

namespace OpenTimesheets.Client.DataRepository
{
    public static class ControllerURL
    {
        public static string urlWorkShift = "api/workshift";
        public static string urlCalendar = "api/calendar";
        public static string urlProjAlloc = "api/projalloc";
    }
    public class TimesheetRepository : ITimesheetRepository
    {

        private IHttpService httpService;

        public TimesheetRepository(IHttpService httpService)
        {
            this.httpService = httpService;

        }

        public async Task<List<CalDayData>> GetCalendarViewData(string username, DateTime date)
        {
            var response = await httpService.Get(ControllerURL.urlCalendar, date);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public List<ProjAlloc> GetProjAlloc(string username, WorkShift workShift)
        {
            throw new NotImplementedException();
        }

        // --- WorkShift Functions ---
        #region WorkShift Functions
        public async Task CreateWorkShift(WorkShift ws)
        {
            var response = await httpService.Post(ControllerURL.urlWorkShift, ws);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public WorkShift GetWorkShift(string username, DateTime date)
        {
            WorkShift ws = new WorkShift();
            try
            {
                Random r = new Random();

                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (r.Next(0, 10) < 8)
                    {
                        return null;  //only work weekend 2/10 times
                    }
                }


                ws.Id = new Random().Next(1, 999);
                ws.Username = "Gordon Freeman";
                ws.UserFk = 22;
                ws.ShiftDate = date;


                ws.ShiftStart = new DateTime(date.Year, date.Month, date.Day, r.Next(6, 9), r.Next(0, 59), 0);
                ws.ShiftEnd = new DateTime(date.Year, date.Month, date.Day, r.Next(16, 20), r.Next(0, 59), 0);

                decimal hrsE = (decimal)(ws.ShiftEnd - ws.ShiftStart).TotalHours;
                ws.HrsElapsed = Math.Round(hrsE, 2);
                ws.HrsBreak = Math.Round((decimal)(r.Next(0, 45) / 60));

                ws.HrsNorm = ws.HrsElapsed - ws.HrsBreak;
            }
            catch (Exception ex)
            {
                //todo: implement logging
            }
            return ws;
        }
        #endregion


        public WorkWeek GetWorkWeek(string username, DateTime date)
        {
            List<WorkShift> workWeek = new List<WorkShift>();
            try
            {
                //get the monday of this week containing date
                int delta = DayOfWeek.Monday - date.DayOfWeek;
                DateTime monday = date.AddDays(delta);

                workWeek.Add(GetWorkShift("", monday));
                workWeek.Add(GetWorkShift("", monday.AddDays(1)));
                workWeek.Add(GetWorkShift("", monday.AddDays(2)));
                workWeek.Add(GetWorkShift("", monday.AddDays(3)));
                workWeek.Add(GetWorkShift("", monday.AddDays(4)));
                workWeek.Add(GetWorkShift("", monday.AddDays(5)));
                workWeek.Add(GetWorkShift("", monday.AddDays(6)));
            }
            catch (Exception ex)
            {
            }
            WorkWeek ww = new WorkWeek();
            ww.WorkShifts = workWeek;
            return ww;
        }

        List<CalDayData> ITimesheetRepository.GetCalendarViewData(string username, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
