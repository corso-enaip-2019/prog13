using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogger;

namespace SimpleLogger
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogError(string message, Exception e);

        void AddTarget(ILogTarget target);

        void RemoveTarget(ILogTarget target);
    }
}
