using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LoggingWithMef
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
