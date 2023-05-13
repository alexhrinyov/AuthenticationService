using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AuthenticationService
{
    public class LogMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            string ip = httpContext.Connection.RemoteIpAddress.ToString();
            _logger.WriteEvent(ip);
            await _next(httpContext);
        }
    }
}
