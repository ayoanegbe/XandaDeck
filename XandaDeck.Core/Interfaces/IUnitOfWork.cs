using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {
        IScheduleItemRepository ScheduleItem { get; }
        IScheduleRepository Schedule { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
