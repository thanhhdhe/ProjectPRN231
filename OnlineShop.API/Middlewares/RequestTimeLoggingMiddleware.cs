using System.Diagnostics;

namespace OnlineShop.API.Middlewares
{
    public class RequestTimeLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeLoggingMiddleware> _logger;

        // Constructor to inject the logger
        public RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        // Middleware Invoke method
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopWatch = Stopwatch.StartNew();  // Start measuring the request time
            await next.Invoke(context);  // Call the next middleware in the pipeline
            stopWatch.Stop();  // Stop the stopwatch after the next middleware has completed

            // If the request took more than 4 seconds, log the information
            if (stopWatch.ElapsedMilliseconds / 1000 > 4)
            {
                _logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms",
                    context.Request.Method,
                    context.Request.Path,
                    stopWatch.ElapsedMilliseconds);
            }
        }
    }
}
