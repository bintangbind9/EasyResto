using EasyResto.Domain.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace EasyResto.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(
                $"An error occurred while processing your request: {exception.Message}");

            var baseResponse = new BaseResponse<string>
            {
                Message = "An error occurred while processing your request.",
                Errors = new List<string> { exception.Message }
            };

            switch (exception)
            {
                case BadHttpRequestException:
                    baseResponse.Status = (int)HttpStatusCode.BadRequest;
                    baseResponse.Title = exception.GetType().Name;
                    break;

                default:
                    baseResponse.Status = (int)HttpStatusCode.InternalServerError;
                    baseResponse.Title = "Internal Server Error";
                    break;
            }

            httpContext.Response.StatusCode = baseResponse.Status;

            await httpContext
                .Response
                .WriteAsJsonAsync(baseResponse, cancellationToken);

            return true;
        }
    }
}
