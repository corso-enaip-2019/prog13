using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.targets
{

    public class LogEntry
    {
        public LogEntry()
        {
            Date = DateTime.Now;
        }
        public enum LogLevel { Info, Warning, Error }

        public LogLevel Level { get; set; }
        public string Message { set; get; }
        public DateTime Date { get; set; }
        public Exception Error { set; get; }
    }
}
