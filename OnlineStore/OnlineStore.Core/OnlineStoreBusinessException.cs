using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core
{
    public class OnlineStoreBusinessException : Exception
    {
        public OnlineStoreBusinessException(string message) : base(message)
        {

        }
    }
}
