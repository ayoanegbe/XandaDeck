using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Data.Models;

namespace XandaDeck.Core.Interfaces
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<IEnumerable<ScheduleItem>> GetScheduleItems(int scheduleId);
    }
}
