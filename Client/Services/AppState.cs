using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenTimesheets.Shared.Entities;

namespace OpenTimesheets.Client.Services
{
    public class AppState
    {
        //public int Counter { get; private set; } = 0;

        //public event Action CalWeekSelectionChanged;
        public string SelectedCalendarWeek { get; private set; }
        public void UpdateSelectedCalendarWeek(ComponentBase src, string calWeek)
        {
            this.SelectedCalendarWeek = calWeek;
            Console.WriteLine("SelectedCalendarWeek: " + calWeek);
            NotifyStateChanged(src, "SelectedCalendarWeek");
        }

        public WorkWeek SelectedWorkWeek { get; private set; }
        public void UpdateSelectedWorkWeek(ComponentBase src, WorkWeek ww)
        {
            this.SelectedWorkWeek = ww;
            Console.WriteLine("SelectedWorkWee: " + ww.ToString());
            NotifyStateChanged(src, "SelectedWorkWeek");
        }

        public WorkShift SelectedWorkShift { get; private set; }
        public void UpdatedSelectedWorkShift(ComponentBase src, WorkShift ws)
        {
            this.SelectedWorkShift = ws;
            Console.WriteLine("SelectedWorkShift: " + ws.ToString());
            NotifyStateChanged(src, "SelectedWorkShift");
        }
        

        public DateTime CalDisplayMonth { get; private set; }
        public void UpdateCalDisplayMonth(ComponentBase src, DateTime dte)
        {
            this.CalDisplayMonth = dte;
            NotifyStateChanged(src, "CalDisplayMonth");
        }


        /*
        public void UpdateCounter(ComponentBase src, int counter)
        {
            this.Counter = counter;
            NotifyStateChanged(src, "Counter");
        }*/

        public event Action<ComponentBase, string> StateChanged;
        private void NotifyStateChanged(ComponentBase Source, string Property)
            => StateChanged?.Invoke(Source, Property);
        
    }
}
