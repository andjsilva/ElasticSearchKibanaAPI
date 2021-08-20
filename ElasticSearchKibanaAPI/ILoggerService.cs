using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchKibanaAPI
{
    public interface ILoggerService
    {
        Task LogInformation(LoggerRequest request);

        Task LogWarning(LoggerRequest request);

        Task LogError(LoggerRequest request);
    }
}
