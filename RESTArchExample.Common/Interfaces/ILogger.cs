using RESTArchExample.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.Common.Interfaces
{
    public interface ILogger
    {
        void DoLog(string message, MessageType type);
    }
}
