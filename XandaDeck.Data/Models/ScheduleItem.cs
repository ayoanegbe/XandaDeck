using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Data.Enums;

namespace XandaDeck.Data.Models
{
    public class ScheduleItem
    {
        public int ScheduleItemId { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public Content Content { get; set; }
        public DateTimeOffset FirstStart { get; set; }
        public DateTimeOffset FirstStop { get; set; }
        public Frequency Frequency { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }
        public DateTimeOffset? RepeatUnitl { get; set; }
        public bool? Forever { get; set; }
    }
}
