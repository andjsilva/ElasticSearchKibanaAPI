using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchKibanaAPI
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;
        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }
        
        public async Task LogError(LoggerRequest request)
        {
            var date = DateTime.UtcNow;
            using (LogContext.PushProperty("ApplicationName",request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.Message))
            using (LogContext.PushProperty("InnerMessage", request.InnerMessage))
            using (LogContext.PushProperty("StackTrace", request.StackTrace))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() => _logger.LogError($"Log Level: Error ApplicationName:{request.ApplicationName} " +
                    $"LogMessage: {request.Message} Date:{date} InnerMessage: {request.InnerMessage} " +
                    $"StackTrace:{request.StackTrace}"));
            }
        }

        public async Task LogInformation(LoggerRequest request)
        {
            var date = DateTime.UtcNow;
            using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.Message))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() => _logger.LogInformation($"Log Level: Information ApplicationName:{request.ApplicationName} " +
                    $"LogMessage: {request.Message} Date:{date} "));
            }
        }

        public async Task LogWarning(LoggerRequest request)
        {
            var date = DateTime.UtcNow;
            using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.Message))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() => _logger.LogWarning($"Log Level: Warning ApplicationName:{request.ApplicationName} " +
                    $"LogMessage: {request.Message} Date:{date} "));
            }
        }
    }
}
