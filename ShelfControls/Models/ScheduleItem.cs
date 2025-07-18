using ShelfControls.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShelfControls.Models
{
    public class ScheduleItem
    {
        public Guid ID { get; set; }
        public TimeOnly Time { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public ScheduleType ScheduleType { get; set; }

        public ScheduleAction ScheduleAction { get; set; }

        public string ScheduleActionData { get; set; }

        public ScheduleItem() { }

        public ScheduleItem(DayOfWeek dayOfWeek, TimeOnly time, ScheduleType scheduleType = ScheduleType.Base, ScheduleAction action = ScheduleAction.Http, string data = "")
        {
            ID = Guid.NewGuid();
            DayOfWeek = dayOfWeek;
            Time = time;
            ScheduleType = scheduleType;
            ScheduleAction = action;
            ScheduleActionData = data;
        }
    }
}
