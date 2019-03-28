using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogger;

namespace ConsoleApp3
{
    class MockLogger : ILogger
    {
        public void AddTarget(ILogTarget target)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message, Exception e)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void RemoveTarget(ILogTarget target)
        {
            throw new NotImplementedException();
        }
    }
}
