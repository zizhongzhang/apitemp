using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    internal class HeaderLogger : DelegatingHandler
    {
        private readonly ILogger<HeaderLogger> _logger;
        public HeaderLogger(ILogger<HeaderLogger> logger)
        {
            _logger = logger;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("##################################### Hey, am excuted! #####################################");
            request.Headers.Add("Custom-header", Guid.NewGuid().ToString());
            return base.SendAsync(request, cancellationToken);
        }
    }

    internal class ResponseHandler : DelegatingHandler
    {
        private readonly ILogger<HeaderLogger> _logger;
        public ResponseHandler(ILogger<HeaderLogger> logger)
        {
            _logger = logger;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            _logger.LogInformation("##################################### Response Header #####################################");
            response.Headers.Add("Custom-response", Guid.NewGuid().ToString());
            return response;
        }
    }
}