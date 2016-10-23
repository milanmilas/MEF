using NLog;

namespace LoggingWithMef.v1
{
    class NLogger1 : ILogger1
    {
        private NLog.ILogger _logger;

        public NLogger1()
        {
            // default logger with 'NLogger1' name
            _logger = LogManager.GetCurrentClassLogger();
        }

        public NLogger1(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }
        public void Log(string message)
        {
            _logger.Info(message);
        }
    }
}
