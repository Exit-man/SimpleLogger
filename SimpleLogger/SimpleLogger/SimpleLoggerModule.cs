using SimpleLogger.Creational;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger
{
    internal class SimpleLoggerModule : ISimpleLoggerModule
    {
        private readonly ISimpleLoggerManagerFactory _simpleLoggerManagerFactory;

        public SimpleLoggerModule(ISimpleLoggerManagerFactory simpleLoggerManagerFactory)
        {
            _simpleLoggerManagerFactory = simpleLoggerManagerFactory;
        }

        public ISimpleLoggerManager GetManager()
        {
            return _simpleLoggerManagerFactory.CreateManager();
        }
    }
}
