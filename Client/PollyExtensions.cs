using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Timeout;

namespace Client
{
    public static class PollyExtensions
    {
        private static readonly AsyncTimeoutPolicy<HttpResponseMessage> TimeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);

        public static IHttpClientBuilder AddTimeoutPolicy(this IHttpClientBuilder builder)
        {
            return builder.AddPolicyHandler(TimeoutPolicy);
        }

    }
}
