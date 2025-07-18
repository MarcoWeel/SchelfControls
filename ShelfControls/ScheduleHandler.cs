using Microsoft.Extensions.Hosting;
using ShelfControls.Helpers;
using ShelfControls.Interfaces;
using ShelfControls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfControls
{
    public class ScheduleHandler : IScheduleHandler
    {
        public List<ScheduleItem> ScheduleItemList { get; set; }

        private readonly string _xmlPath;

        public ScheduleHandler()
        {
            string currentPath = Directory.GetCurrentDirectory();
            _xmlPath = Path.Combine(currentPath, "Schedule.xml");
            ScheduleItemList = XMlHelper.DeserializeFromXml<ScheduleItem>(_xmlPath);
        }

        public bool AddToSchedule(ScheduleItem item)
        {
            ScheduleItemList.Add(item);
            XMlHelper.SerializeToXml(ScheduleItemList, _xmlPath);
            return true;
        }

        public bool RemoveFromSchedule(Guid id)
        {
            var item = ScheduleItemList.First(x=> x.ID == id);
            ScheduleItemList.Remove(item);
            XMlHelper.SerializeToXml(ScheduleItemList, _xmlPath);
            return true;
        }

        public List<ScheduleItem> GetAllSchedules()
        {
            return ScheduleItemList;
        }

        public List<ScheduleItem> GetSchedulesOfToday(DayOfWeek dayOfWeek)
        {
            return ScheduleItemList.Where(x=> x.DayOfWeek == dayOfWeek).ToList();
        }
    }
}
