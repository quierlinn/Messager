using System.Net;

public abstract class GlobalExceptionHandler
{
    protected readonly RequestDelegate _next;
    protected readonly ILogger<GlobalExceptionHandler> _logger;

    protected GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public abstract (HttpStatusCode code, string message) GetResponse(Exception exception);

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Global exception handler caught exception");
            
            var response = context.Response;
            response.ContentType = "application/json";

            var (status, message) = GetResponse(ex);
            response.StatusCode = (int)status;
            
            await response.WriteAsync(message);
        }
    }
}