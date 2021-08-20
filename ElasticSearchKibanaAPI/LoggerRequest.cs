using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchKibanaAPI
{
    public class LoggerRequest
    {
        public string ApplicationName { get; set; }

        public string Message { get; set; }

        public string InnerMessage { get; set; }

        public string StackTrace { get; set; }

    }
}
