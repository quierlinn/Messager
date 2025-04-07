using System.Net;
using System.Text.Json;
using Messager.Messager.UnitOfWork.CustomExceptions;
using Microsoft.EntityFrameworkCore;

namespace Messager.Messager.UnitOfWork;

public class MessengerExceptionHandlerMiddleware : GlobalExceptionHandler
{
    public MessengerExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandler> logger) : base(next, logger)
    {
    }

    public override (HttpStatusCode code, string message) GetResponse(Exception exception)
    {
        HttpStatusCode code;
        switch (exception)
        {
            case UserAlreadyExistsException:
                code = HttpStatusCode.Conflict;
                break;
            
            case InvalidUserDataException:
                code = HttpStatusCode.BadRequest;
                break;
            case KeyNotFoundException
                or ArgumentException:
                code = HttpStatusCode.NotFound;
                break;
            case UnauthorizedAccessException:
                code = HttpStatusCode.Unauthorized;
                break;
            case InvalidMessageException
                or ArgumentException
                or InvalidOperationException:
                code = HttpStatusCode.BadRequest;
                break;
            case DbUpdateException:
                code = HttpStatusCode.InternalServerError;
                return (code, JsonSerializer.Serialize(new
                {
                    Error = "Database operation failed",
                    Detail = exception.InnerException?.Message ?? exception.Message
                }));
            default:
                code = HttpStatusCode.InternalServerError;
                break;
        }
        return (code, JsonSerializer.Serialize(new{Error = exception.Message}));
    }
}