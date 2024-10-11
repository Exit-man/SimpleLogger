using SimpleLogger.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace SimpleLogger.Implementation
{
    internal class Logger : ILogger
    {
        string _logPath;
        IList<string> _loggedEvents;

        public string LogPath
        {
            get => _logPath;
            set => _logPath = value;
        }
        public IList<string> LoggedEvents
        {
            get => _loggedEvents;
        }

        public Logger()
        {
            _loggedEvents = new List<string>();
            _logPath = RuntimeEnvironment.GetRuntimeDirectory();
        }

        public void LogToEventList(string message)
        {
            _loggedEvents.Add(message);
        }

        public void LogToFile(string message)
        {
            CreateLogFolder();
            string filename = "\\SimpleLog" + DateTime.Today.Date.ToString() + ".txt";
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(_logPath, filename)))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }

        private void CreateLogFolder()
        {
            if (string.IsNullOrEmpty(_logPath))
            {
                _logPath = RuntimeEnvironment.GetRuntimeDirectory();
            }

            Path.GetFullPath(Path.Combine(_logPath, "\\SimpleLoggerLogs"));
            if (!System.IO.Directory.Exists(_logPath))
            {
                System.IO.Directory.CreateDirectory(_logPath);
            }

        }

    }
}
