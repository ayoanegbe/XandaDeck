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
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        private new readonly ApplicationDbContext _context;

        public ScheduleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScheduleItem>> GetScheduleItems(int scheduleId)
        {
            return await _context.ScheduleItems.Where(c => c.ScheduleId == scheduleId).ToListAsync();
        }
    }
}
