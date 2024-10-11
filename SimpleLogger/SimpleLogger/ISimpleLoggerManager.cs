using SimpleLogger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger
{
    public interface ISimpleLoggerManager
    {
        void SetUpLogPath(string logPath);
        IList<string> GetEventLog();
        void Log(LogTarget target, string message);
    }
}
