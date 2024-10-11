using SimpleLogger.DomainModel;

namespace SimpleLogger.Creational
{
    internal interface ISimpleLoggerManagerFactory
    {
        ISimpleLoggerManager CreateManager();
    }

    internal class SimpleLoggerManagerFactory : ISimpleLoggerManagerFactory
    {
        private readonly ILogger _logger;

        public SimpleLoggerManagerFactory( ILogger logger)
        {
            _logger = logger;
        }

        public ISimpleLoggerManager CreateManager()
        {
            return new SimpleLoggerManager(_logger);
        }

    }
}
