using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Core.Interfaces;
using XandaDeck.Data.Contexts;
using XandaDeck.Data.Models;

namespace XandaDeck.Core.Repositories
{
    public class ScheduleItemRepository : Repository<ScheduleItem>, IScheduleItemRepository
    {
        private new readonly ApplicationDbContext _context;

        public ScheduleItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetScheduleItemCount(int scheduleId)
        {
            return await _context.ScheduleItems.Where(g => g.ScheduleId == scheduleId).CountAsync();
        }
    }
}
