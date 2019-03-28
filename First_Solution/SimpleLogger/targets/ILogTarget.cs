using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogger.targets;

namespace SimpleLogger
{
    public interface ILogTarget
    {
        void WriteLog(LogEntry entry);
    }
}
