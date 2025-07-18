using ShelfControls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfControls.Interfaces
{
    public interface IScheduleHandler
    {
        public bool AddToSchedule(ScheduleItem item);

        public bool RemoveFromSchedule(Guid id);

        public List<ScheduleItem> GetAllSchedules();

        public List<ScheduleItem> GetSchedulesOfToday(DayOfWeek dayOfWeek);
    }
}
