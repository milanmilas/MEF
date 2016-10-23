using System.ComponentModel.Composition;
using System.Diagnostics;
using NLog;

namespace LoggingWithMef.v2
{
    class NLogger2 : ILogger2
    {
        private NLog.ILogger _logger;

        public NLogger2(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }
        public void Log(string message)
        {
            _logger.Info(message);
        }
    }
}
