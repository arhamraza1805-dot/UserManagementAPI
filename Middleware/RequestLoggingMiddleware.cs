namespace UserManagementAPI.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var start = DateTime.UtcNow;
        _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);

        try
        {
            await _next(context);
        }
        finally
        {
            var elapsed = (DateTime.UtcNow - start).TotalMilliseconds;
            _logger.LogInformation("Response: {StatusCode} in {Elapsed}ms", context.Response.StatusCode, elapsed);
        }
    }
}