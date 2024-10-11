using System;
using System.Collections.Generic;
using System.Text;
using SimpleLogger.DomainModel;
using SimpleLogger.Enums;

namespace SimpleLogger
{
    internal class SimpleLoggerManager : ISimpleLoggerManager
    {
        private readonly ILogger _logger;

        public SimpleLoggerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void SetUpLogPath (string logPath)
        {
            _logger.LogPath = logPath;
        }

        public IList<string> GetEventLog()
        {
            return _logger.LoggedEvents;
        }

        /*
        Can be expanded with Database logging but for that you should create a Database class to encapsulate the required parameters and methods. Also you need a method for setting up the database connection
        */
        public void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    _logger.LogToFile(message);
                    break;
                case LogTarget.EventLog:
                    _logger.LogToEventList(message);
                    break;
                default:
                    return;
            }
        }

    }
}
