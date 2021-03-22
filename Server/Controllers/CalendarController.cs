using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenTimesheets.Shared.Entities;
using OpenTimesheets.Shared;
using DateTimeExtensions;


namespace OpenTimesheets.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ApplicationDbContext context;


        public CalendarController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //[HttpGet("{date}")]
        [HttpGet]
        public async Task<ActionResult<List<CalDayData>>> Get([FromQuery] DateTime date)
        {
            List<CalDayData> dayList = new List<CalDayData>();


            try
            {
                //param date could be anything.  Move it to the first day of the month
                DateTime dte = new DateTime(date.Year, date.Month, 1);

                //what day of week is this? (dow)
                DayOfWeek dow = dte.DayOfWeek;

                //count backwards until we hit monday. (our calendar is Mon >> Sun)
                while (dow != DayOfWeek.Monday)
                {
                    dte = dte.AddDays(-1);
                    dow = dte.DayOfWeek;
                }
                Console.WriteLine("FirstDayOfMonth: " + dte.ToString("yyyy-MM-dd ddd"));

                //dte now equals the first cell of the calendar.
                DateTime ldte = dte.LastDayOfTheMonth();
                dow = ldte.DayOfWeek;
                while (dow != DayOfWeek.Sunday)
                {
                    ldte = ldte.AddDays(1);
                    dow = ldte.DayOfWeek;
                }

                //get all the information between the required dates
                //SELECT * FROM table WHERE username = '' AND date >= dte AND date <= ldte
                int daysBetween = 42;//(int)ldte.Subtract(dte).TotalDays;
                for (int i = 0; i < daysBetween; i++)
                {
                    CalDayData dd = new CalDayData();
                    dd.CalDay = dte.AddDays(i);

                    var result = await context.WorkShifts.Where(q => q.ShiftDate == dd.CalDay).FirstOrDefaultAsync();
                    if(result != null)
                    {
                        dd.HrsWorked = result.HrsNorm;
                        dd.HrsAllocated = 0; //todo: needs to be implemented
                        dd.Username = result.Username;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return  dayList;
        }
    }
}
