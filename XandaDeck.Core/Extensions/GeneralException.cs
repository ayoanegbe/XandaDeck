using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Core.Extensions
{
    [Serializable]
    public class GeneralException : Exception
    {
        public GeneralException()
        {                
        }

        public GeneralException(string message) : base(message)
        {
        }
    }
}
