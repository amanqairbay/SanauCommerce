using System.Text.Json;
using Catalog.Application.Exceptions;
using Catalog.Core.Logging;

namespace Catalog.API.Middlewares;

/// <summary>
/// Represents an exeption middleware.
/// </summary>
internal sealed class CatalogExceptionHandlingMiddleware : IMiddleware
{   
    // about exception handling middleware: https://code-maze.com/cqrs-mediatr-fluentvalidation

    private readonly ILoggerManager _logger;

    public CatalogExceptionHandlingMiddleware(ILoggerManager logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);

        var response = new
        {
            title = GetTitle(exception),
            status = statusCode,
            detail = exception.Message,
            errors = GetErrors(exception)
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            CatalogValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    
    private static string GetTitle(Exception exception) =>
        exception switch
        {
            CatalogApplicationException applicationException => applicationException.Title,
            _ => "Server Error"
        };
        
    private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
    {
        IReadOnlyDictionary<string, string[]> errors = null!;

        if (exception is CatalogValidationException validationException)
        {
            errors = validationException.Errors;
        }

        return errors;
    }
}