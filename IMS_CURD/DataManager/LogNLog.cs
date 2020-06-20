using IMS_CURD.Repository;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace IMS_CURD.DataManager
{
    public class LogNLog : ILog
    {
        private static readonly ILogger logger = (ILogger)LogManager.GetCurrentClassLogger();

        public LogNLog()
        {
        }

        public void Information(string message)
        {
            logger.LogInformation(message);
        }

        public void Warning(string message)
        {
            logger.LogWarning(message);
        }

        public void Debug(string message)
        {
            logger.LogDebug(message);
        }

        public void Error(string message)
        {
            logger.LogError(message);
        }
    }
}