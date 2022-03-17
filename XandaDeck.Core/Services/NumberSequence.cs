using Microsoft.EntityFrameworkCore;
using XandaDeck.Data.Contexts;
using XandaDeck.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XandaDeck.Core.Services
{
    public class NumberSequence : INumberSequence
    {
        private readonly ApplicationDbContext _context;

        public NumberSequence(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetNumberSequence(SequenceType sequenceType)
        {
            string result = "";

            try
            {
                int counter = 0;

                var sequence = await _context.Sequences.Where(s => s.SequenceType == sequenceType).FirstOrDefaultAsync();

                if (sequence == null)
                {
                    Interlocked.Increment(ref counter);

                    sequence = new Sequence
                    {
                        SequenceType = sequenceType,
                        LastNumber = counter,
                        SequenceName = sequenceType.ToString()
                    };
                                       
                    _context.Add(sequence);
                    _context.SaveChanges();
                }
                else
                {
                    counter = sequence.LastNumber;

                    Interlocked.Increment(ref counter);
                    sequence.LastNumber = counter;

                    _context.Update(sequence);
                    _context.SaveChanges();
                }

                result = "P" + counter.ToString().PadLeft(5, '0');
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
