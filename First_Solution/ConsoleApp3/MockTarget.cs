using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogger;
using SimpleLogger.targets;

namespace ConsoleApp3
{
    class MockTarget : ILogTarget
    {
        public void WriteLog(LogEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
