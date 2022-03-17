using XandaDeck.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Core.Services
{
    public interface INumberSequence
    {
        Task<string> GetNumberSequence(SequenceType sequenceType);
    }
}
