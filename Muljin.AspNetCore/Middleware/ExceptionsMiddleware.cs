using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Muljin.Exceptions;
using System;

namespace Muljin.AspNetCore.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsMiddleware> _logger;

        public ExceptionsMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<ExceptionsMiddleware>() ?? null;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ConflictException ex)
            {
                LogExceptionWarning(ex);
                await SetContextError(context, 409, ex);
            }
            catch (UnauthorizedException ex)
            {
                LogExceptionWarning(ex);
                await SetContextError(context, 403, ex);
            }
            catch (RecordNotFoundException ex)
            {
                LogExceptionWarning(ex);
                await SetContextError(context, 404, ex);
            }
            catch (UserNotFoundException ex)
            {
                LogExceptionWarning(ex);
                await SetContextError(context, 404, ex);
            }
            catch (UserActionException ex)
            {
                LogExceptionWarning(ex);
                await SetContextError(context, 400, ex);
            }
            catch (ServiceUnavailableException ex)
            {
                LogExceptionError(ex);
                await SetContextError(context, 503, ex);
            }
            catch(MuljinException ex)
            {
                LogExceptionError(ex);
                await SetContextError(context, 500, ex);
            }
        }

        private void LogExceptionError(Exception ex)
        {
            if (_logger != null)
            {
                _logger.LogError(ex, "Error caught by exception middleware");
            }
        }

        private void LogExceptionWarning(Exception ex)
        {
            if (_logger != null)
            {
                _logger.LogWarning(ex, "Exception caught and handled by middleware");
            }
        }

        private async Task SetContextError(HttpContext context, int statusCode, MuljinException exception)
        {
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new ErrorResult{ 
                Success = false, Message = exception.Message, ErrorCode = exception.ErrorCode }));
        }
    }

    public static class ExceptionsMiddlewareExtension
    {
        public static IApplicationBuilder UseMuljinExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
