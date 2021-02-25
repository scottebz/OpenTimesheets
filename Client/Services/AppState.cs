using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTimesheets.Client.Services
{
    public class AppState
    {
        public int Counter { get; private set; } = 0;

        //public event Action CalWeekSelectionChanged;
        public string SelectedCalendarWeek { get; private set; }
        public void UpdateSelectedCalendarWeek(ComponentBase src, string calWeek)
        {
            this.SelectedCalendarWeek = calWeek;
            Console.WriteLine("SelectedCalendarWeek: " + calWeek);
            NotifyStateChanged(src, "SelectedCalendarWeek");
        }

        public void UpdateCounter(ComponentBase src, int counter)
        {
            this.Counter = counter;
            NotifyStateChanged(src, "Counter");
        }

        public event Action<ComponentBase, string> StateChanged;
        private void NotifyStateChanged(ComponentBase Source, string Property)
            => StateChanged?.Invoke(Source, Property);
        
    }
}
