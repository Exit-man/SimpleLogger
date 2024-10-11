using System.Collections.Generic;

namespace SimpleLogger.DomainModel
{
    internal interface ILogger
    {
        string LogPath { set; get; }
        IList<string> LoggedEvents { get; }
        void LogToFile(string message);
        void LogToEventList(string message);
    }
}
