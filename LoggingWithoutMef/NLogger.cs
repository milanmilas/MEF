using NLog;
using ILogger = LoggingWithMef.ILogger;

namespace LoggingWithoutMef
{
    class NLogger : ILogger
    {
        private NLog.ILogger _logger;
        public NLogger(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }
        public void Log(string message)
        {
            _logger.Info(message);
        }
    }
}
