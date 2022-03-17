using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Data.Models;

namespace XandaDeck.Core.Interfaces
{
    public interface IScheduleItemRepository : IRepository<ScheduleItem>
    {
        public Task<int> GetScheduleItemCount(int scheduleId);
    }
}
