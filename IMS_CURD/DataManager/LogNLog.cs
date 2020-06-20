using IMS_CURD.Repository;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace IMS_CURD.DataManager
{
    public class LogNLog : ILog    {
        
        private readonly ILogger<LogNLog> _logger;

       
        public LogNLog(ILogger<LogNLog> logger)
        {
            _logger = logger;
        }
        public void Information(string message)
        {
            _logger.LogInformation(message);
        }

        public void Warning(string message)
        {
            _logger.LogWarning(message);
        }

        public void Debug(string message)
        {
            _logger.LogDebug(message);
        }

        public void Error(string message)
        {
            _logger.LogError(message);
        }
    }
}